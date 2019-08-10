using System;
using DemoProject.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace DemoProject.Data.Db
{
    public class ApplicationContext : DbContext 
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderToProduct> OrderToProducts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
            Database.Migrate();
        }
    }
}
