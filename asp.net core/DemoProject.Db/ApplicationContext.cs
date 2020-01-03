using System;
using DemoProject.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace DemoProject.Data.Db
{
    public class ApplicationContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SomeStaff> SomeStaffs { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
            Database.Migrate();
        }
    }
}
