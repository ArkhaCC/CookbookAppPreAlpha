using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookbookApp.Model.CookbookApp.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CookbookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    //class MyDatabase : DbContext
    //{
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        base.OnConfiguring(optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Cookbook;MultipleActiveresultSets=True")); //Database Connection String (MSSQLLocalDB)
    //    }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        //modelBuilder.Entity<Recipe>().HasData(); TODO: Needs to be filled with sample data
    //        base.OnModelCreating(modelBuilder);
    //    }

    //    //public DbSet<Recipe> RecipeTable { get; set; }
    //}
}
