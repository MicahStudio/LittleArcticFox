using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LittleArcticFox.EntityFrameworkCore.Entity
{
    /// <summary>
    /// 带审计的实体（只是多了一个软删除）
    /// </summary>
    public abstract class AuditedEntity : AuditedEntity<int>
    {
    }
    /// <summary>
    /// 带审计的实体（只是多了一个软删除）
    /// </summary>
    public abstract class AuditedEntity<TPKey> : Entity<TPKey>, IAuditedEntity<TPKey> where TPKey : struct
    {
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { set; get; } = DateTime.Now;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastModificationTime { set; get; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DeletionTime { set; get; }
    }
}
