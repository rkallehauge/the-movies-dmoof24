using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    public class ShowingOverviewViewModel : ViewModelBase
    {
        private MovieRepository movieRepo = new MovieRepository();

        public ObservableCollection<MovieViewModel> MoviesVM { get; set; } = new ObservableCollection<MovieViewModel>();

        public MovieViewModel SelectedMovie { get; set; }

        public ShowingOverviewViewModel()
        {
            List<Movie> movies = movieRepo.GetAll();
            foreach (Movie movie in movies)
            {
                MoviesVM.Add(new MovieViewModel(movie));
            }
        }
    }
}
