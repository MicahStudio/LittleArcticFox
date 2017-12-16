using LittleArcticFox.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleActicFox.Simple.Application
{
    /// <summary>
    /// Applicaiton基类
    /// </summary>
    public abstract class MyBaseApplication : AppService
    {
        /// <summary>
        /// 
        /// </summary>
        public string ApplicationName { get; } = "不需要名字";
    }
}
