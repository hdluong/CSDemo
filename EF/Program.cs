using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    class Program
    {
        static void CreateDatabase()
        {
            using var dbcontext = new ShopContext();
            var dbname = dbcontext.Database.GetDbConnection().Database;

            var result = dbcontext.Database.EnsureCreated();

            if (result)
            {
                Console.WriteLine($"Create db {dbname} sucessfully!");
            }
            else
            {
                Console.WriteLine($"Create db {dbname} unsucessfully!");
            }
        }

        static void DropDatabase()
        {
            using var dbcontext = new ShopContext();
            var dbname = dbcontext.Database.GetDbConnection().Database;

            var result = dbcontext.Database.EnsureDeleted();

            if (result)
            {
                Console.WriteLine($"Delete db {dbname} sucessfully!");
            }
            else
            {
                Console.WriteLine($"Delete db {dbname} unsucessfully!");
            }
        }

        static void InsertData()
        {
            using var dbcontext = new ShopContext();

            Category c1 = new Category() { Name = "Dien thoai", Description = "Cac loai dien thoai" };
            Category c2 = new Category() { Name = "Do uong", Description = "Cac loai do uong" };
            dbcontext.Categories.Add(c1);
            dbcontext.Categories.Add(c2);

            dbcontext.Add(new Product() { Name = "Iphone 8", Price = 1000, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Samsung", Price = 900, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Ruou vang Abc", Price = 500, CateId = 2 });
            dbcontext.Add(new Product() { Name = "Nokia xyz", Price = 600, CateId = 1 });
            dbcontext.Add(new Product() { Name = "Cafe ABc", Price = 100, CateId = 2 });
            dbcontext.Add(new Product() { Name = "Nuoc ngot", Price = 50, CateId = 2 });
            dbcontext.Add(new Product() { Name = "Bia", Price = 200, CateId = 2 });

            dbcontext.SaveChanges();
        }

        static void Main(string[] args)
        {
            DropDatabase();
            CreateDatabase();
            InsertData();

            //using var dbcontext = new ShopContext();
            //var category = dbcontext.Categories.Where(x => x.CategoryId == 1).FirstOrDefault();
            //dbcontext.Remove(category);
            //dbcontext.SaveChanges();
        }
    }
}
