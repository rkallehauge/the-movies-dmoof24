using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    internal class MainViewModel
    {
        Movie movie = new Movie();
        MovieRepository movieRepository = new MovieRepository();
        public ICommand CreateMovieCommand { get; set; } = new CreateCommand();

        public string Title { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
    }
}
