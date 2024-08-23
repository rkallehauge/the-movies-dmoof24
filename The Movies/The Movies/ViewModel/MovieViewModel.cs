using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model;

namespace The_Movies.ViewModel
{
    public class MovieViewModel
    {
        private Movie movie;

		public string? Title { get; set; }
		public string? Genre { get; set; }
		public int? Duration { get; set; }
		public string? Director { get; set; }
		public DateOnly PremierDate { get; set; }

		public MovieViewModel(Movie movie)
		{
			Title = movie.Title;
			Genre = movie.Genre;
			Duration = movie.Duration;
			Director = movie.Director;
			PremierDate = movie.PremierDate;
		}
	}
}
