using LittleArcticFox.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LittleArcticFox.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注册LittleArcticFox框架
        /// </summary>
        /// <param name="services"></param>
        /// <param name="servicesActionSetup"></param>
        public static void RegisterLittleArcticFox(this IServiceCollection services, Action<ModuleOptions> servicesActionSetup = null)
        {
            servicesActionSetup?.Invoke(new ModuleOptions());
        }
    }
}
