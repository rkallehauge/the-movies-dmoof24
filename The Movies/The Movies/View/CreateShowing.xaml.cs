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
            
            //CINEMA
            cbCinema.ItemsSource = csvm.Cinemas; //ItemsSource for biograf combobox er Cinesmas listen i VM...

            SelectionChangedEventHandler cinemaSelectionHandler = (sender, e) =>
            {
                csvm.SelectedCinema = (Model.Cinema)cbCinema.SelectedItem;
            };
            
            cbCinema.SelectionChanged += cinemaSelectionHandler;



            //MOVIE
            cbMovie.ItemsSource = csvm.Movies; //ItemsSource for film combobox er Movies listen i VM...

            SelectionChangedEventHandler movieSelectionHandler = (sender, e) =>
            {
                csvm.SelectedMovie = (Model.Movie) cbMovie.SelectedItem;
            };

            cbMovie.SelectionChanged += movieSelectionHandler;

            //DATE
            EventHandler<SelectionChangedEventArgs> dateSelectionHandler = (sender, e) =>
            {
                csvm.SelectedDate = DateOnly.FromDateTime((DateTime)dpShowing.SelectedDate);
            };

            dpShowing.SelectedDateChanged += dateSelectionHandler;

            //TIME
            SelectionChangedEventHandler timeSelectionHandler = (sender, e) =>
            {
                csvm.SelectedTime = TimeOnly.Parse(((ComboBoxItem)cbTime.SelectedItem).Content.ToString());
            };

            cbTime.SelectionChanged += timeSelectionHandler;

            //SCREEN
            cbScreen.ItemsSource = csvm.Showings; //ItemsSource for biograf combobox er Cinesmas listen i VM...

            SelectionChangedEventHandler showingSelectionHandler = (sender, e) =>
            {
                csvm.SelectedScreen = (Model.Screen) cbScreen.SelectedItem;
            };

            cbScreen.SelectionChanged += showingSelectionHandler;
        }


	}
}
