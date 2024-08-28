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
    public class ShowingOverviewViewModel : ViewModelBase
    {
        private Repository<Movie> movieRepo = MovieRepository.GetInstance();
        private Repository<Cinema> cinemaRepo = CinemaRepository.GetInstance();
        private Repository<Showing> showingRepo = ShowingRepository.GetInstance();

        private Showing selectedShowing;

        public Showing SelectedShowing
        {
            get { return selectedShowing; }
            set { 
                selectedShowing = value;
            }
        }

        private DateOnly selectedDate;
        public DateOnly SelectedDate
        {
            get { return selectedDate; }
            set { 

                selectedDate = value;
                DateChanged();
            }
        }

        private List<TimeOnly> availableTimes;
        public List<TimeOnly> AvailableTimes
        {
            get { return availableTimes; }
            set { availableTimes = value; }
        }


        private TimeOnly selectedAvailableTime;
        public TimeOnly SelectedAvailableTime
        {
            get { return selectedAvailableTime; }
            set { 
                selectedAvailableTime = value; 
                UpdateAvailableScreens();
            }
        }


        private Screen selectedAvailableScreen;
        public Screen SelectedAvailableScreen
        {
            get { return selectedAvailableScreen; }
            set { selectedAvailableScreen = value; }
        }

        private List<Screen> availableScreens;
        public List<Screen> AvailableScreens
        {
            get { return availableScreens; }
            set { availableScreens = value; }
        }

        private List<Showing> showingsForDate;

        private List<Showing> showings;
        public List<Showing> Showings
        {
            get { return showings; }
            set { showings = value; }
        }


        public event EventHandler ShowingsUpdated;

        private void UpdateShowings()
        {
            ShowingsUpdated?.Invoke(this, EventArgs.Empty);
            for(int i = 0; i < 9; i++)
            {
                int startingHour = 13;

                Predicate<Showing> isSameHour = (showing) =>
                {
                    return showing.ShowingTime.Hour == startingHour + i;
                };

                if(showings.FindAll(isSameHour).Count < 5)
                {
                    availableTimes.Add(new TimeOnly(startingHour + i, 0));
                    Debug.WriteLine($"available hour : {startingHour + i}");
                }

            }
        }

        private void UpdateAvailableScreens()
        {
            Predicate<Showing> showingIsAtSelectedTime = (showing) => {
                return TimeOnly.FromDateTime(showing.ShowingTime).Equals(selectedAvailableTime);
            };

            List<Showing> showingAtSameTime = showings.FindAll(showingIsAtSelectedTime);
            foreach(Showing showing in showingAtSameTime)
            {
                Debug.WriteLine(showing.Screen.ScreenNumber);
            }



        }


        List<Cinema> cinemas;
        public List<Cinema> Cinemas { get {  return cinemas; } }


        List<Movie> movies;
        public List<Movie> Movies { get { return movies;  } set { movies = value; } }

        private Movie selectedMovie;
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
            }
        }



        private Cinema selectedCinema;
        public Cinema SelectedCinema
        {
            get { return selectedCinema; }
            set { 
                selectedCinema = value;
                Debug.WriteLine($"Success! {value.Name}");
            }
        }


        public void DateChanged()
        {

            
            showingsForDate = ShowingRepository.GetByDate(selectedDate);

            Debug.WriteLine(showingsForDate.Count);
            if(showingsForDate is null || showingsForDate.Count == 0)
            {
                // TODO : Depopulate list?
                return;
            }

            Predicate<Showing> IsSameCinema = (showing) =>
            {
                return showing.Screen.Cinema.Equals(selectedCinema);
            };

            showings = showingsForDate.FindAll(IsSameCinema);
            UpdateShowings();

        }
        public ShowingOverviewViewModel()
        {
            cinemas = cinemaRepo.GetAll();
            movies = movieRepo.GetAll();

            availableTimes = new();
            availableScreens = new();

            //showingGigaList = new();
        }
    }
}
