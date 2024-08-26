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
        private Repository<Showing> showingRepo = ShowingRepository.GetInstance();
        
        public CreateShowingViewModel()
        {
            cinemas = cinemaRepo.GetAll(); 

            movies = movieRepo.GetAll(); 

            showings = showingRepo.GetAll();

        }



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


        //MOVIE
        List<Movie> movies;
        public List<Movie> Movies { get { return movies; } }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                Debug.WriteLine($"Success! {value.Title}");
            }
        }

        //TIME
        private TimeOnly selectedTime;
        public TimeOnly SelectedTime
        {
            get { return selectedTime; }
            set
            {
                selectedTime = value;
                Debug.WriteLine($"Succes! {value.Hour}:{value.Minute}" );
            }
        }



        //DATE

        private DateOnly selectedDate;
        public DateOnly SelectedDate
        {
            get { return selectedDate; }
            set
            {

                selectedDate = value;
                Debug.WriteLine($"Success! {value.Day}");
                //DateChanged();
            }
        }


        //SCREEN
        List<Showing> showings;
        public List<Showing> Showings { get { return showings; } }

        private Screen selectedScreen;
        public Screen SelectedScreen
        {
            get { return selectedScreen; }
            set
            {

                selectedScreen = value;
                Debug.WriteLine($"Success! {value.ScreenNumber}");
                //DateChanged();
            }
        }

    }
}
