using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Movies.Command;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private MovieRepository movieRepo = new MovieRepository();

		public event PropertyChangedEventHandler? PropertyChanged;

		public ObservableCollection<MovieViewModel> MovieVM { get; set; } = new ObservableCollection<MovieViewModel>();


		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				CreateCmd.RaiseCanExecuteChanged();
			}
		}

		private string _genre;
		public string Genre
		{
			get { return _genre; }
			set
			{
				_genre = value;
				CreateCmd.RaiseCanExecuteChanged();
			}
		}

		private string _duration;
		public string Duration
		{

			get { return _duration; }
			set
			{
				_duration = value;
				CreateCmd.RaiseCanExecuteChanged();
			}
		}

		public MainViewModel()
        {
            foreach (Movie movie in movieRepo.GetAll())
            {
                MovieVM.Add(new MovieViewModel(movie));
            }
        }

        public CreateMovie CreateCmd { get; set; } = new CreateMovie();
    }
}
