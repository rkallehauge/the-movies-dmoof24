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


        private DateOnly selectedDate;
        public DateOnly SelectedDate
        {
            get { return selectedDate; }
            set { 

                selectedDate = value;
                DateChanged();
            }
        }


        private List<List<Showing>> showingHallList;
        public List<List<Showing>> ShowingHallList
        {
            get { return showingHallList; }
            set { showingHallList = value; }
        }

        private List<Showing> showingsForDate;
        public List<Showing> ShowingsForDate
        {
            get { return showingsForDate; }
            set { showingsForDate = value; }
        }


        List<Cinema> cinemas;
        public List<Cinema> Cinemas { get {  return cinemas; } }


        public ObservableCollection<MovieViewModel> MoviesVM { get; set; } = new ObservableCollection<MovieViewModel>();
        public MovieViewModel SelectedMovie { get; set; }



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


            // populate gigalist
            for(int i = 1; i <= 5; i++)
            {

            }

        }
        public ShowingOverviewViewModel()
        {
            cinemas = cinemaRepo.GetAll();

            List<Movie> movies = movieRepo.GetAll();
            foreach (Movie movie in movies)
            {
                MoviesVM.Add(new MovieViewModel(movie));
            }

            //showingGigaList = new();
        }
    }
}
