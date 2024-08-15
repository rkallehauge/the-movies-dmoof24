using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Movies.Model;
using The_Movies.Command;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration;


namespace The_Movies.ViewModel
{
    internal class MainViewModel
    {

        MovieRepository movieRepository;
        private bool canCreate;

        private int durationStore;

        public bool CanCreate
        {
            get { return canCreate; }
        }

        private CreateMovie? createMovieCommand;
        public CreateMovie? CreateMovieCommand
        {
            get { return createMovieCommand; }
        }

        public MainViewModel()
        {
            Movie movie = new Movie();
            movieRepository = new MovieRepository();
        }

        public void init()
        {
            createMovieCommand = new CreateMovie(MovieCreatable, MovieCreate);
        }


        public bool MovieCreatable(object param)
        {
            if (String.IsNullOrEmpty(title) || String.IsNullOrEmpty(genre) || String.IsNullOrEmpty(duration))
            {
                return false;
            }
            if(!int.TryParse(duration, out durationStore))
            {
                return false;
            }

            return true;
        }


        public void MovieCreate(object param)
        {
            Movie movie = new Movie();

            movie.Title = title;
            movie.Genre = genre;
            movie.Duration = durationStore;
            movieRepository.Add(movie);
            
        }
        private void checkUpdateableStatus()
        {
            createMovieCommand.RaiseCanExecuteChanged();
        }


        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; checkUpdateableStatus(); }
        }
        private string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; checkUpdateableStatus(); }
        }

        private string duration;
        public string Duration
        {
            get { return duration; }
            set { duration = value; checkUpdateableStatus(); }
        }

       
    }
}
