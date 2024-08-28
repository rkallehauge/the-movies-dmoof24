using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace The_Movies.Command
{
    public class RelayCommand : ICommand
    {
        Predicate<object> MethodCanExecute { get; set; }
        Action<object> MethodExecute {  get; set; }
        public event EventHandler CanExecuteChanged;


        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            MethodCanExecute = canExecute;
            MethodExecute = execute;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            return MethodCanExecute(parameter);
        }

        public void Execute(object obj)
        {
            Execute(obj);
        }
    }
}
