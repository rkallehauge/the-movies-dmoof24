using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    internal class MovieRepository
    {
        List<Movie>? _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }

        public void Add(Movie movie)
        {
            if(_movies is not null)
                _movies.Add(movie);
        }
    }
}
