using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace LittleArcticFox.Exceptions
{
    sealed class ExceptionEvent
    {
        private readonly RequestDelegate next;
        public ExceptionEvent(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"异常拦截:{ex.Message}");
            }
        }
    }
}
