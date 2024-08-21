using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using The_Movies.Helper;

namespace The_Movies
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Start off with importing .csv from either excel or persistence to then continue with
        Importer importer = new Importer();
    }
}
