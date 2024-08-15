using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using The_Movies.ViewModel;

namespace The_Movies.Command
{
    internal class CreateMovie : ICommand
    {
        MainViewModel _mainViewModel;


        public CreateMovie(Func<object, bool> canExecute, Action<object> method)
        {
            MethodExecute = method;
            MethodCanExecute = canExecute;
        }

        public Action<object> MethodExecute { get; set; }
        public Func<object, bool> MethodCanExecute { get; set; }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return MethodExecute != null && MethodCanExecute.Invoke(parameter);
        }


        public void Execute(object parameter) 
        {
           MethodExecute(parameter);
        }


    }
}
