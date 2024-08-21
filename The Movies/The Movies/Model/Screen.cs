using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    internal class Screen
    {

        public int ScreenNumber { get; set; }

        public Screen() { }

        public Screen(int screenNumber) { 
            ScreenNumber = screenNumber;
        }
    }
}
