using System;
using System.Collections.Generic;
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



        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Movie)) return false;
            Showing other = obj as Showing;

            if(other.Movie != Movie) return false;
            if(other.Screens != Screens) return false;
            if(other.ShowingTime != ShowingTime) return false;
            
            return true;
        }
    }
}
