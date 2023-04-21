using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSProject.Model
{
    public class DatabaseManager
    {
        DatabaseContext DbContext;
        public DatabaseManager()
        {
            DbContext = new DatabaseContext();
        }

        public List<Movie> GetMovies()
        {
            return DbContext.Movies.ToList();
        }

        public List<Car> GetCars()
        {
            return DbContext.Cars.ToList();
        }
    }
}
