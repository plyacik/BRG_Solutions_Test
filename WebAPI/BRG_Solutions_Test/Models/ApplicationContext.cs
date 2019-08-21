using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRG_Solutions_Test.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local)\\MSSQLKLASIK; Database=BRG_Solutions_Test_DB; Trusted_Connection=True; MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasData(
                new CategoryProduct[]
                {
                new CategoryProduct { Id=1, CategoryName="Apple"},
                new CategoryProduct { Id=2, CategoryName="Potato"},
                new CategoryProduct { Id=3, CategoryName="Orange"},
                new CategoryProduct { Id=4, CategoryName="Peach"},
                new CategoryProduct { Id=5, CategoryName="Plum"},
                new CategoryProduct { Id=6, CategoryName="Watermelon"},
                new CategoryProduct { Id=7, CategoryName="Strawberry"},
                new CategoryProduct { Id=8, CategoryName="Cucumber"},
                new CategoryProduct { Id=9, CategoryName="Pear"}
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
