﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    public class Screen
    {
        Cinema _cinema;
        public Cinema Cinema { get { return _cinema; } set { _cinema = value; } }

        public int ScreenNumber { get; set; }

        public Screen() { }

        public Screen(int screenNumber, Cinema cinema) { 
            _cinema = cinema;
            ScreenNumber = screenNumber;
        }


    }
}
