using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace PSProject.Model
{
    internal class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Data Source=GAS-LAPTOP;Initial Catalog=PSProject;Integrated Security=True") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
