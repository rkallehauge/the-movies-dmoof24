using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    internal class Cinema
    {
        int screenAmount = 5;

        List<Screen> screens;
        public List<Screen> Screens { get { return Screens; } }

        public string Name { get; set; }
        public string CityName { get; set; }

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
            for (int i = 1; i <= Screens.Count; i++)
            {
                screens.Add(new Screen(i));
            }
        }
    }
}
