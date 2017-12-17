using LittleArcticFox.EntityFrameworkCore.Repositories;
using LittleArcticFox.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleArcticFox.EntityFrameworkCore.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 开启EF
        /// </summary>
        /// <param name="moduleOptions"></param>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ModuleOptions AddEFCore<TDbContext>(this ModuleOptions moduleOptions, IServiceCollection services) where TDbContext : DbContext
        {
            services.AddSingleton(typeof(LAFDbContext), typeof(TDbContext));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            return moduleOptions;
        }
    }
}
