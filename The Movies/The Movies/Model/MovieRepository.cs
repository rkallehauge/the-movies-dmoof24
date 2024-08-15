using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    internal class MovieRepository
    {
        List<Movie> _movies;

        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }
    }
}
