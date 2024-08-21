using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Movies.Model
{
    public class Movie
    {
		public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? Duration { get; set; }


        public override string ToString()
        {
            return $"Title:{Title} Genre:{Genre} {Duration} length in minutes";
        }
    }
}
