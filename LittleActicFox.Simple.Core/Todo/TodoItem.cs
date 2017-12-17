using LittleArcticFox.EntityFrameworkCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LittleActicFox.Simple.Core.Todo
{
    public class TodoItem : AuditedEntity
    {
        public string Title { set; get; }
        public string Content { set; get; }
    }
}
