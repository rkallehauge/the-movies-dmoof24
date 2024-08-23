using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.ViewModel
{

    // TODO : Debate whether viewmodels accesibility should be public or internal for testing?
    public class ViewModelBase : INotifyPropertyChanged
    {
        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        // Gigascuffed solution
        

    }
}
