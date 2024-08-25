using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using The_Movies.ViewModel;

namespace The_Movies.View
{
    /// <summary>
    /// Interaction logic for CreateShowing.xaml
    /// </summary>
    public partial class CreateShowing : Window
    {
        public CreateShowing()
        {
            InitializeComponent();
            CreateShowingViewModel csvm = new CreateShowingViewModel();
            DataContext = csvm;
            
            
            cbCinema.ItemsSource = csvm.Cinemas; //ItemsSource for biograf combobox er Cinesmas listen i VM...

            SelectionChangedEventHandler cinemaSelectionHandler = (sender, e) =>
            {
                csvm.SelectedCinema = (Model.Cinema)cbCinema.SelectedItem;
            };
            
            cbCinema.SelectionChanged += cinemaSelectionHandler;




            cbMovie.ItemsSource = csvm.Movies; //ItemsSource for biograf combobox er Cinesmas listen i VM...

            SelectionChangedEventHandler cinemaSelectionHandler = (sender, e) =>
            {
                csvm.SelectedMovie = (Model.Movie)cbMovie.SelectedItem;
            };

            cbMovie.SelectionChanged += movieSelectionHandler;
        }


	}
}
