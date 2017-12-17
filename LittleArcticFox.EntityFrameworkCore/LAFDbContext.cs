using LittleArcticFox.EntityFrameworkCore.Entity;
using LittleArcticFox.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LittleArcticFox.EntityFrameworkCore
{
    /// <summary>
    /// DbContext的基类
    /// </summary>
    public abstract class LAFDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public LAFDbContext(DbContextOptions options) : base(options)
        {
            //Cfg.dbContextOptions = options;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes().Where(t => t.FindProperty("IsDeleted") != null))
            {
                modelBuilder.FilterDelete(entity.ClrType);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <returns></returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveFilter();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnSaveFilter();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        /// <summary>
        /// 过滤审计实体的软删除
        /// </summary>
        private void OnSaveFilter()
        {
            foreach (var entity in ChangeTracker.Entries().Where(t => t.Entity is AuditedEntity))
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        {
                            entity.State = EntityState.Modified;
                            entity.CurrentValues["IsDeleted"] = true;
                            //entity.CurrentValues["DeletionTime"] = DateTime.Now;
                            break;
                        }
                }
            }
        }
    }
}
