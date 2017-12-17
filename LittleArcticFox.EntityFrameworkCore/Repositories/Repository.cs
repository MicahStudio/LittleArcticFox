using LittleArcticFox.EntityFrameworkCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LittleArcticFox.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPKey"></typeparam>
    public class Repository<TEntity, TPKey> : IRepository<TEntity, TPKey> where TEntity : class, IEntity<TPKey>, IAuditedEntity<TPKey>
    {
        private readonly LAFDbContext _dbContext;
        private DbSet<TEntity> Table => _dbContext.Set<TEntity>();
        public Repository(LAFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity Get(TPKey key) => Table.Find(key);

        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<TEntity> GetAsync(TPKey key) => Table.FindAsync(key);
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="entity"></param>
        public void Instert(TEntity entity)
        {
            Table.Add(entity);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task InstertAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteById(TPKey key)
        {
            var entity = Table.Find(key);
            Table.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteByIdAsync(TPKey key)
        {
            var entity = await Table.FindAsync(key);
            Table.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Table.ToListAsync();
        }
    }
}
