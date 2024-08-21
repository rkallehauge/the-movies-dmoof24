using The_Movies;
using The_Movies.Model;
using The_Movies.Model.Repo;

namespace TheMoviesTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateCinemaAndScreens()
        {
            // Create Cinema
            Cinema cinema = new Cinema();
            cinema.Name = "Test Cinema 1";
            cinema.CityName = "Aalborg";

            
        }
    }
}