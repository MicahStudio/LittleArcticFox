using LittleActicFox.Simple.Core.Todo;
using LittleArcticFox.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleActicFox.Simple.EntityFrameworkCore
{
    public class SimpleDbContext : LAFDbContext
    {
        public virtual DbSet<TodoItem> TodoItems { set; get; }
        public SimpleDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
