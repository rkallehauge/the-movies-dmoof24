using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


            SelectionChangedEventHandler selectedAvailableTimeHandler = (sender, e) =>
            {
                sovm.SelectedAvailableTime = cbTime.SelectedItem as TimeOnly;
            };

            cbTime.SelectionChanged += selectedAvailableTimeHandler;


            SelectionChangedEventHandler selectedAvailableScreenHandler = (sender, e) =>
            {
                Debug.WriteLine(cbScreen.SelectedItem);
            };
            cbScreen.SelectionChanged += selectedAvailableScreenHandler;

            EventHandler showingsUpdateHandler = (sender, e) => {
                foreach (Showing showing in sovm.Showings)
                {
                    Screen screen = showing.Screen;

                         StackPanel stackPanel = new StackPanel();

                        stackPanel.Height = 50;
                        stackPanel.Width = 130;

                        Label label = new Label();
                        label.Content = showing.Movie.Title;

                        label.HorizontalAlignment = HorizontalAlignment.Center;
                        label.VerticalAlignment = VerticalAlignment.Center;

  
                        stackPanel.Children.Add(label);

                        stackPanel.SetValue(Grid.ColumnProperty, screen.ScreenNumber);

                        int hour = showing.ShowingTime.Hour;

                        stackPanel.SetValue(Grid.RowProperty, hour - 13);
                        // 13 -> 21

                        Button button = new Button();

                        button.Width = 50;
                        button.Height = 30;
                        button.Content = "Edit";

                        RoutedEventHandler clickListener = (sender, e) =>
                        {
                            sovm.SelectedShowing = showing;
                        };

                        button.Click += clickListener;

                        stackPanel.Children.Add(button);


                        Showings.Children.Add(stackPanel);
                    
                }
            };

            sovm.ShowingsUpdated += showingsUpdateHandler;

                        
        }

       

    }
}
