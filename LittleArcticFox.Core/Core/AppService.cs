using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LittleArcticFox.Core
{
    /// <summary>
    /// AppService的服务的基类
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public abstract class AppService : Controller
    {
        //private readonly 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext action = await next();
            action.Result = new JsonResult(new
            {
                Success = action?.Exception == null,
                //Code = "--------",
                Result = (action?.Result as ObjectResult)?.Value,
                action?.Exception?.Message
            });
            //返回结果：JsonConvert.SerializeObject(result?.Result)
            //异常:JsonConvert.SerializeObject(result?.Exception)
            //ServerName = context.ActionDescriptor.DisplayName,
            //IPAddress = context.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
            //ExecutionTime = start,
            //Parameters = JsonConvert.SerializeObject(context.ActionArguments),
            //Result = JsonConvert.SerializeObject(result.Result),
            //Duration = (DateTime.Now - start).TotalMilliseconds,
            //Exception = JsonConvert.SerializeObject(result?.Exception)
        }
    }
}
