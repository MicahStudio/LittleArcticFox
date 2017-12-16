using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LittleActicFox.Simple.Application.AppServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAppSimple
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<string> GetString();
    }
}
