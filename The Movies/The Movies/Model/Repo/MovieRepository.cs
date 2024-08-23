using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model.Repo;

namespace The_Movies.Model
{
    public class MovieRepository : Repository<Movie>
    {
        List<Movie> _movies = new List<Movie>
        {
            new Movie {Title = "Hej", Genre = "Gyser", Duration = 146, Director = "René Mose Hansen", PremierDate = DateOnly.Parse("23-08-2024") },

            new Movie {Title = "Hej2", Genre = "Gyser", Duration = 156, Director = "René Mose Hansen", PremierDate = DateOnly.Parse("23-08-2025") },

            new Movie {Title = "Hej3", Genre = "Gyser", Duration = 166, Director = "René Mose Hansen", PremierDate = DateOnly.Parse("23-08-2026") }

        };

        public MovieRepository() 
        {
            foreach (var item in _movies)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
