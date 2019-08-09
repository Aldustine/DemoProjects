using System;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data.Db
{
    public class ApplicationContext : DbContext 
    {


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
            Database.Migrate();
        }
    }
}
