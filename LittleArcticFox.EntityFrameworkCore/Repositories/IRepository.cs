using LittleArcticFox.EntityFrameworkCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LittleArcticFox.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository
    {
    }
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TPKey">主键类型</typeparam>
    public interface IRepository<TEntity, TPKey> : IRepository where TEntity : class, IEntity<TPKey>, IAuditedEntity<TPKey>
    {
        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Get(TPKey key);
        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TPKey key);
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="entity"></param>
        void Instert(TEntity entity);
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task InstertAsync(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void DeleteById(TPKey key);
        Task DeleteByIdAsync(TPKey key);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
