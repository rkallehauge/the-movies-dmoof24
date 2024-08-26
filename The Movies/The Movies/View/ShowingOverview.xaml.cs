using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using The_Movies.Model;
using The_Movies.ViewModel;

namespace The_Movies.View
{
    /// <summary>
    /// Interaction logic for ShowingOverview.xaml
    /// </summary>
    public partial class ShowingOverview : Window
    {
        public ShowingOverview()
        {
            InitializeComponent();
            ShowingOverviewViewModel sovm = new ShowingOverviewViewModel();
            DataContext = sovm;
            cbCinema.ItemsSource = sovm.Cinemas;

            SelectionChangedEventHandler cinemaSelectionHandler = (sender, e) =>
            {
                sovm.SelectedCinema = (Model.Cinema)cbCinema.SelectedItem;
            };

            cbCinema.SelectionChanged += cinemaSelectionHandler;


            EventHandler<SelectionChangedEventArgs> dateSelectionHandler = (sender, e) =>
            {
                sovm.SelectedDate =  DateOnly.FromDateTime((DateTime)dpShowing.SelectedDate);
            };

            dpShowing.SelectedDateChanged += dateSelectionHandler;
                        
        }

       

    }
}
