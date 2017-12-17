using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LittleArcticFox.EntityFrameworkCore.Entity
{
    /// <summary>
    /// 实体的基类
    /// </summary>
    public abstract class Entity : Entity<int>
    {
        ///// <summary>
        ///// 主键
        ///// </summary>
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        ///// <summary>
        ///// 防止并发冲突
        ///// </summary>
        //[ConcurrencyCheck, Timestamp]
        //public byte[] Timestamp { get; set; }
    }
    /// <summary>
    /// 实体的基类
    /// </summary>
    public abstract class Entity<TPKey> : IEntity<TPKey> where TPKey : struct
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TPKey Id { get; set; }
        /// <summary>
        /// 防止并发冲突
        /// </summary>
        [ConcurrencyCheck, Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
