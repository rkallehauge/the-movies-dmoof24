using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    public class Cinema
    {
        readonly int screenAmount = 5;

        List<Screen> screens;
        public List<Screen> Screens { get { return screens; } }

        public string? Name { get; set; }
        public string? CityName { get; set; }

        public Cinema()
        {
            initScreens();
        }
        
        public Cinema(string name, string cityName)
        {

            Name = name;
            CityName = cityName;

            initScreens();
        }

        private void initScreens()
        {
            screens = new List<Screen>();
            for (int i = 1; i <= screenAmount; i++)
            {
                screens.Add(new Screen(i, this));
            }
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(Cinema)) return false;

            Cinema other = obj as Cinema;
            if(other.Name != Name) return false;
            if(other.CityName != CityName) return false;

            return true;
        }
    }
}
