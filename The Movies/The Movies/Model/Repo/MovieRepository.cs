using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using The_Movies.Model.Repo;
using Windows.Devices.PointOfService;

namespace The_Movies.Model
{
    public class MovieRepository : Repository<Movie>
    {


        public Movie GetMovie(string Title)
        {
            List<Movie> movies = base.GetAll();
            foreach (Movie movie in movies)
            {
                if (movie.Title == Title)
                {
                    return movie;
                }
            }
            return null;
        }
    }
}
