using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using The_Movies.Helper;
using The_Movies.Model.Repo;
using The_Movies.Model;
using System.Diagnostics;
using The_Movies.View;

namespace The_Movies
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        string exportFile = "output.csv";

        public App()
        {

            ShowingOverview showing = new ShowingOverview();

            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".csv"; // Default file extension
            dialog.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }


            Importer importer = new Importer();
            Repository<Cinema> cinemaRepo = CinemaRepository.GetInstance();
            Debug.WriteLine(cinemaRepo);

            importer.CinemaRepo = cinemaRepo;

            Repository<Movie> movieRepo = MovieRepository.GetInstance();

            importer.MovieRepo = movieRepo;
            //Repository<Showing> showingRepo = ShowingRepository.GetInstance();

            importer.Import(dialog.FileName, exportFile);

            



            showing.Show();
        }
    }
}
