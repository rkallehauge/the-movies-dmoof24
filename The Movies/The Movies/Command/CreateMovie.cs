using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using The_Movies.Model;
using The_Movies.ViewModel;

namespace The_Movies.Command
{
    public class CreateMovie : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
			bool result = true;

			if (parameter is MainViewModel mvm)
			{
				if (String.IsNullOrEmpty(mvm.Title) || String.IsNullOrEmpty(mvm.Genre) || String.IsNullOrEmpty(mvm.Duration))
				{
					result = false;
				}
			}
			return result;
		}

        public void Execute(object parameter) 
        {
            //if (parameter is MainViewModel mainViewModel) 
            //{
            //    mainViewModel.MovieVM.Add(new MovieViewModel(new Movie { Title = "Ny film", Genre = "Ny Genre", Duration = "Ny Duration" }));
            //}
			MainViewModel MovieVM
        }
		public void RaiseCanExecuteChanged() 
		{ 
			CanExecuteChanged?.Invoke(this, EventArgs.Empty); 
		}
	}
}
