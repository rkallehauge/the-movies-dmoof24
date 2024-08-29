using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using WinRT;

namespace The_Movies.View
{
    /// <summary>
    /// Interaction logic for ShowingOverview.xaml
    /// </summary>
    public partial class ShowingOverview : Window
    {

        public EventHandler ChangeToCreate;

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
                sovm.SelectedAvailableTime = TimeOnly.Parse(cbTime.SelectedItem.ToString());
            };

            cbTime.SelectionChanged += selectedAvailableTimeHandler;


            SelectionChangedEventHandler selectedAvailableScreenHandler = (sender, e) =>
            {
                Debug.WriteLine(cbScreen.SelectedItem);
            };
            cbScreen.SelectionChanged += selectedAvailableScreenHandler;

            EventHandler showingsUpdateHandler = (sender, e) => {

                List<UIElement> list = new List<UIElement>();
                foreach(UIElement elem in Showings.Children)
                {

                    if((int)elem.GetValue(Grid.ColumnProperty) != 0)
                    {
                        list.Add(elem);
                    } 
                }
                foreach(UIElement elem in list)
                {
                    Showings.Children.Remove(elem);
                }


                if(sovm.SelectedCinema is null || sovm.SelectedDate == null)
                {
                    return;
                }

                foreach (Showing showing in sovm.Showings)
                {
                    Screen screen = showing.Screen;

                        StackPanel stackPanel = new StackPanel();

                        stackPanel.Height = 150;
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
                            //Debug.WriteLine($"current showing : {showing.Movie.Title}");


                        };

                        button.Click += clickListener;

                        stackPanel.Children.Add(button);


                        Showings.Children.Add(stackPanel);
                    
                }
            };

            EventHandler availableScreensHandler = (sender, e) =>
            {
                cbScreen.ItemsSource = sovm.AvailableScreens;
            };

            EventHandler BindSelectedShowingData = (sender, e) =>
            {
                cbCinemaEdit.SelectedItem = sovm.SelectedShowing.Screen.Cinema;
                cbMovie.SelectedItem = sovm.SelectedShowing.Movie;
                cbTime.SelectedItem = TimeOnly.FromDateTime(sovm.SelectedShowing.ShowingTime);


                sovm.AvailableScreens.Add(sovm.SelectedShowing.Screen);
                cbScreen.ItemsSource = sovm.AvailableScreens;

                cbScreen.SelectedItem = sovm.SelectedShowing.Screen;
            };

            sovm.ShowingsUpdated += showingsUpdateHandler;
            sovm.AvailableScreensUpdated += availableScreensHandler;
            sovm.EditClicked += BindSelectedShowingData;
            Showings.MouseLeftButtonDown += CalculateGridPosition;


        }


        /**
         * Hit detection for grid from ChatGPT
         * */
        private void CalculateGridPosition(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;

            // Get the position of the mouse click relative to the grid
            Point point = e.GetPosition(grid);

            // Determine the row
            int rowIndex = 0;
            double accumulatedHeight = 0.0;
            foreach (var rowDefinition in grid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                rowIndex++;
            }

            // Determine the column
            int columnIndex = 0;
            double accumulatedWidth = 0.0;
            foreach (var columnDefinition in grid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                columnIndex++;
            }

            // TODO : Determine whether position pressed is either label for time, or is populated with showing




            //CreateShowingEventArgs e = new();
            //e.TimeForShowing = 


            //ChangeToCreate?.Invoke(this, EventArgs.Empty);
        }


        public class CreateShowingEventArgs : EventArgs
        {
            public DateTime TimeForShowing { get; set; }
        }


    }
}
