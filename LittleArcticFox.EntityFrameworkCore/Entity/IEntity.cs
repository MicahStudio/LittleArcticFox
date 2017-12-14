    using System;
using System.Collections.Generic;
using System.Text;

namespace LittleArcticFox.EntityFrameworkCore.Entity
{
    public interface IEntity : IEntity<int>
    {
    }
    public interface IEntity<TPKey>
    {
    }
    public interface IAuditedEntity : IEntity<int>
    {

    }
    public interface IAuditedEntity<TPkey> : IEntity<TPkey>
    {

    }
}
