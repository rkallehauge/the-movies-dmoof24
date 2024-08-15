using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Movies.ViewModel;

namespace The_Movies.Command
{
    internal class CreateMovie : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        { return true; }

        public void Execute(object parameter) 
        {
            if (parameter is MainViewModel mainViewModel) 
            { 
            mainViewModel.
            }
        }
    }
}
