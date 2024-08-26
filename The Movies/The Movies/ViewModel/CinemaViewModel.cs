using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    public class CinemaViewModel
    {
        private Cinema cinema;   
        public string? Name { get; set; }
        public string? CityName { get; set; }

        public List<Screen> Screens { get; set; }


        public CinemaViewModel(Cinema cinema)
        {
            Screens = cinema.Screens;
            Name = cinema.Name;
            CityName = cinema.CityName;

        }
       
    }
}
