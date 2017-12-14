using LittleArcticFox.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LittleActicFox.Simple.Application.AppServices
{
    /// <summary>
    /// 
    /// </summary>
    public class AppSimple : AppService
    {
        /// <summary>
        /// 测试用的方法
        /// </summary>
        /// <returns>一个字符串</returns>
        [HttpGet]
        public Task<string> GetString()
        {
            return Task.FromResult("Hello Little Actic Fox.");
        }
    }
}
