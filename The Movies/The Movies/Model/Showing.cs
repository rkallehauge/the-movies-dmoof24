using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace The_Movies.Model
{
    public class Showing
    {

        public Movie Movie { get; set; }
        public List<Screen> Screens { get; set; }
        public DateTime ShowingTime { get; set; }

        public Showing()
        {
            Screens = new List<Screen>();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;


            if (obj.GetType() != typeof(Showing)) return false;

            Showing other = obj as Showing;

            

            if (!other.Movie.Equals(Movie)) return false;

            if (!other.ShowingTime.Equals(ShowingTime)) return false;

            if (!other.Screens.FirstOrDefault().Cinema.Equals(Screens.FirstOrDefault().Cinema)) return false;

            Debug.WriteLine("gets here");
            
            return true;
        }
    }
}
