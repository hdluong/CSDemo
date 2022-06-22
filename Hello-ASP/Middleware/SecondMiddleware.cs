using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_ASP
{
    public class SecondMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                
                var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (datafromFirstMiddleware != null)
                {
                    await context.Response.WriteAsync((string)datafromFirstMiddleware);
                }

                await context.Response.WriteAsync("Ban khong duoc truy cap");
            }
            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban duoc truy cap");
                var datafromFirstMiddleware = context.Items["DataFirstMiddleware"];
                if (datafromFirstMiddleware != null)
                {
                    await context.Response.WriteAsync((string)datafromFirstMiddleware);
                }

                await next(context);
            }
        }
    }
}
