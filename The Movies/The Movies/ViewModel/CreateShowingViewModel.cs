using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model;
using The_Movies.Model.Repo;

namespace The_Movies.ViewModel
{
    public class CreateShowingViewModel : ViewModelBase
    {
        private Repository<Movie> movieRepo = MovieRepository.GetInstance();
        private Repository<Cinema> cinemaRepo = CinemaRepository.GetInstance();
        
        
        public ObservableCollection<MovieViewModel> MoviesVM { get; set; } = new ObservableCollection<MovieViewModel>();
        public MovieViewModel SelectedMovie { get; set; }


        //CINEMA
        List<Cinema> cinemas;
        public List<Cinema> Cinemas { get { return cinemas; } }

        private Cinema selectedCinema;

        public Cinema SelectedCinema
        {
            get { return selectedCinema; }
            set
            {
                selectedCinema = value;
                Debug.WriteLine($"Success! {value.Name}");
            }
        }

        public CreateShowingViewModel()
        {
            cinemas = cinemaRepo.GetAll(); //Skal den ikke puttes ind i en VMliste? 

            List<Movie> movies = movieRepo.GetAll();
            foreach (Movie movie in movies)
            {
                MoviesVM.Add(new MovieViewModel(movie));
            }

        }


        //MOVIE
        //List<Cinema> movies;
        //public List<Cinema> Movies { get { return cinemas; } }

        //private Movie selectedMovie;

        //public Movie SelectedMovie
        //{
        //    get { return selectedMovie; }
        //    set
        //    {
        //        selectedMovie = value;
        //        Debug.WriteLine($"Success! {value.Name}");
        //    }
        //}


    }
}
