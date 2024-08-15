using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    public class MovieRepository
    {
        List<Movie> movies = new List<Movie>();

        public List<Movie> GetAll()
        {
            return movies;
        }
    }
}
