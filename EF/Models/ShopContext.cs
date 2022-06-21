using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class ShopContext : DbContext
    {
        private const string connectionString = @"
            Data Source=SM116\MSSQL_SERVER;
            Initial Catalog=shopdata;
            User ID=sa;
            Password=123
            ";

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
