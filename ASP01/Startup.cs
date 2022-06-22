using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP01
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<TestOptionsMiddleware>();

            //services.AddSingleton<ProductNames>();

            //services.AddOptions();

            //var testOptions = _configuration.GetSection("TestOptions");

            //services.Configure<TestOptions>(testOptions);

            services.AddDistributedMemoryCache();

            services.AddSession((option) =>
            {
                option.Cookie.Name = "TestSession";
                option.IdleTimeout = new TimeSpan(0, 30, 0);
            });

            // dotnet sql-cache create "Data Source = SM116\MSSQL_SERVER;Initial Catalog = webdb;User ID = sa;Password = 123" dbo Session
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            //app.UseMiddleware<TestOptionsMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    int? count;

                    count = context.Session.GetInt32("count");

                    if (count == null)
                    {
                        count = 0;
                    }

                    await context.Response.WriteAsync($"So lan truy cap rwsession: {count.Value}\n");
                    
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/rwsession", async (context) =>
                {
                    int? count;

                    count = context.Session.GetInt32("count");

                    if (count == null)
                    {
                        count = 0;
                    }

                    count += 1;
                    context.Session.SetInt32("count", count.Value);

                    await context.Response.WriteAsync($"So lan truy cap rwsession: {count.Value}");
                });

                endpoints.MapGet("/ShowOptions", async (context) =>
                {
                    //var configuration = context.RequestServices.GetService<IConfiguration>();

                    //var testOptions = configuration.GetSection("TestOptions");

                    //var opt_key1 = testOptions["opt_key1"];

                    //var k1 = testOptions.GetSection("opt_key2")["k1"];
                    //var k2 = testOptions.GetSection("opt_key2")["k2"];

                    //var sb = new StringBuilder();
                    //sb.Append("TestOptions\n");
                    //sb.Append($"opt_key1 = {opt_key1}\n");
                    //sb.Append($"opt_key2.k1 = {k1}\n");
                    //sb.Append($"opt_key2.k2 = {k2}");

                    //var testOptions = configuration.GetSection("TestOptions").Get<TestOptions>();
                    //var testOptions = context.RequestServices.GetService<IOptions<TestOptions>>().Value;

                    //var sb = new StringBuilder();
                    //sb.Append("TestOptions\n");
                    //sb.Append($"opt_key1 = {testOptions.opt_key1}\n");
                    //sb.Append($"opt_key2.k1 = {testOptions.opt_key2.k1}\n");
                    //sb.Append($"opt_key2.k2 = {testOptions.opt_key2.k2}");

                    await context.Response.WriteAsync("Show Options");
                });
            });
        }
    }
}
