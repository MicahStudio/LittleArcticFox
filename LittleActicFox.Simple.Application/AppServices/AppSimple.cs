using LittleArcticFox.Core;
using Microsoft.AspNetCore.Authorization;
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
    public class AppSimple : MyBaseApplication, IAppSimple
    {
        /// <summary>
        /// 测试用的方法
        /// </summary>
        /// <returns>一个字符串</returns>
        [HttpGet]
        //[Authorize]
        public async Task<string> GetString()
        {
            return await Task.FromResult(ApplicationName);
        }
    }
}
