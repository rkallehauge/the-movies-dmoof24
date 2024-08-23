using The_Movies;
using The_Movies.Model;
using The_Movies.Model.Repo;

namespace TheMoviesTesting
{
    [TestClass]
    public class UnitTest1
    {
        string name = "Test Cinema 1";
        string cityName = "Aalborg";
        Cinema cinema;

        CinemaRepository cinemaRepository;


        [TestInitialize]
        public void Init()
        {
            // Create Cinema
            cinema = new Cinema();
            cinema.Name = name;
            cinema.CityName = cityName;

            cinemaRepository = new CinemaRepository();
            cinemaRepository.Add(cinema);
        }

        [TestMethod]
        public void CinemaNamesSetCorrectly()
        {
            Assert.AreEqual(cinema.Name, name);
            Assert.AreEqual(cinema.CityName, cityName);
        }
    }
}