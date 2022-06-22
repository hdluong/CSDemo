using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP01
{
    public class TestOptionsMiddleware : IMiddleware
    {
        private TestOptions testOptions { get; set; }

        private ProductNames ProductNames { get; set; }

        public TestOptionsMiddleware(IOptions<TestOptions> options, ProductNames product)
        {
            testOptions = options.Value;
            ProductNames = product;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Show options in TestOptionsMiddleware\n");

            var sb = new StringBuilder();
            sb.Append("TestOptions\n");
            sb.Append($"opt_key1 = {testOptions.opt_key1}\n");
            sb.Append($"opt_key2.k1 = {testOptions.opt_key2.k1}\n");
            sb.Append($"opt_key2.k2 = {testOptions.opt_key2.k2}\n");

            foreach (var item in ProductNames.GetNames())
            {
                sb.Append(item + "\n");
            }

            await context.Response.WriteAsync(sb.ToString());

            await next(context);
        }
    }
}
