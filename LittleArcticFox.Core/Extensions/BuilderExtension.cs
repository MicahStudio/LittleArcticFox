using LittleArcticFox.Modules;
using Microsoft.AspNetCore.Builder;
using System;

namespace LittleArcticFox.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class BuilderExtension
    {
        /// <summary>
        /// 注册LittleArcticFox框架
        /// </summary>
        /// <param name="app"></param>
        /// <param name="appActionSetup"></param>
        public static void RegisterLittleArcticFox(this IApplicationBuilder app, Action<ModuleOptions> appActionSetup = null)
        {
            appActionSetup?.Invoke(new ModuleOptions());
        }
    }
}
