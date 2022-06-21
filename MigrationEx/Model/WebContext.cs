using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MigrationEx
{
    public class WebContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ArticleTag> ArticleTag { get; set; }

        private const string connectionString = @"
            Data Source=SM116\MSSQL_SERVER;
            Initial Catalog=webdb;
            User ID=sa;
            Password=123
            ";

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create((builder) =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasIndex(articleTag => new { articleTag.ArticleId, articleTag.TagId })
                      .IsUnique();
            });
        }
    }
}
