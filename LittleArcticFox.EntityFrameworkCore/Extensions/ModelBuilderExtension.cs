﻿using LittleArcticFox.EntityFrameworkCore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LittleArcticFox.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// ModelBuilder的扩展
    /// </summary>
    internal static class ModelBuilderExtension
    {
        static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(ModelBuilderExtension).GetMethods(BindingFlags.Public | BindingFlags.Static).Single(t => t.IsGenericMethod && t.Name == nameof(FilterDelete));
        public static void FilterDelete(this ModelBuilder modelBuilder, Type clrType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(clrType).Invoke(null, new object[] { modelBuilder });
        }
        public static void FilterDelete<TEntity>(this ModelBuilder modelBuilder) where TEntity : AuditedEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
