using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace PSProject.Model
{
    internal class MovieContext : DbContext
    {
        public MovieContext() : base("Data Source=GAS-LAPTOP;Initial Catalog=PSProject;Integrated Security=True") { }
        public DbSet<Movie> Movies { get; set; }
    }
}
