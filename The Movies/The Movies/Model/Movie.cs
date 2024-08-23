using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace The_Movies.Model
{
    public class Movie
    {
		public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? Duration { get; set; }
        public string? Director { get; set; }
        public DateOnly PremierDate { get; set; }

        public override string ToString()
        {
            return $"Title:{Title} Genre:{Genre} {Duration} length in minutes";
        }


        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Movie)) return false;

            Movie other = obj as Movie;
            if (other.Title != Title) return false;
            if (other.Genre != Genre) return false;
            if (other.Duration != Duration) return false;

            return true;
        }
    }
}
