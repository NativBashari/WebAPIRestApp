using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class APIDbContext : DbContext
    {
        public DbSet<Person>? Persons { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<Salary>? Salaries { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public APIDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=API_DB;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Server=tcp:api-test.database.windows.net,1433;Initial Catalog=API_DB;Persist Security Info=False;User ID=adminstrator;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
