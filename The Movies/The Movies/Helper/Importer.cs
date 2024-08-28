using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using The_Movies.Model;
using The_Movies.Model.Repo;
using Windows.ApplicationModel.Contacts;

namespace The_Movies.Helper
{
    /**
     * Creates classes
     */
    public class Importer
    {
        StreamReader reader;
        StreamWriter writer;



        private Repository<Cinema> cinemaRepo;
        public Repository<Cinema> CinemaRepo
        {
            get { return cinemaRepo; }
            set { cinemaRepo = value; }
        }

        private Repository<Movie> movieRepo;
        public Repository<Movie> MovieRepo
        {
            get { return movieRepo; }
            set { movieRepo = value; }
        }

        private Repository<Showing> showingRepo;
        public Repository<Showing> ShowingRepo
        {
            get { return showingRepo; }
            set { showingRepo = value; }
        }

        public Importer()
        {
            
        }


        public void Import(string importFile, string exportFile)
        {
            reader = new StreamReader(importFile);
            string line;




            reader.ReadLine();

            while ((line = reader.ReadLine()) != null)
            {
                // Debug.WriteLine(line);
                string[] strings = line.Split(';');

                string cinemaName = strings[0];
                string cinemaCityName = strings[1];

                Cinema cinema = new Cinema();

                cinema.Name = cinemaName;
                cinema.CityName = cinemaCityName;

                List<Cinema>? cinemas = CinemaRepo.GetAll();

                if (cinemas is null || cinemas.Count == 0 || !cinemas.Contains(cinema))
                {
                    CinemaRepo.Add(cinema);
                }

                Movie movie = new Movie();

                //3-7

                string movieTitle = strings[3];
                string movieGenre = strings[4];
                // Parse 01:34 as Hour and minutes ( 01 * 60 ) + ( 34 ) => 94
                int movieDuration = (int.Parse(strings[5].Split(':')[0]) * 60) + int.Parse(strings[5].Split(':')[1]);
                string movieDirector = strings[6];
                DateOnly movePremiereDate = DateOnly.Parse(strings[7]);

                movie.Title = movieTitle;
                movie.Genre = movieGenre;
                movie.Duration = movieDuration;
                movie.Director = movieDirector;
                movie.PremierDate = movePremiereDate;

                List<Movie>? movies = MovieRepo.GetAll();

                if(movies is null || movies.Count == 0 || !movies.Contains(movie))
                {
                    MovieRepo.Add(movie);
                }

                Showing showing = new Showing();
                showing.ShowingTime = DateTime.Parse(strings[2]);


                // TODO : showing.Movie may potentially point to a different instance than the one stored in the repository
                showing.Movie = movie;


                showingRepo = ShowingRepository.GetInstance();
                List<Showing> showings = ShowingRepository.GetByDate(DateOnly.FromDateTime(showing.ShowingTime));

                Predicate<Showing> sameCinema = (other) =>
                {
                    return other.Screen.Cinema.Equals(cinema);
                };

                List<Showing> sameCinemaShowings = showings.FindAll(sameCinema);

                Predicate<Showing> sameTimeOfDay = (other) =>
                {
                    //Debug.WriteLine("Multiple showings for one time");
                    return (other.ShowingTime.Equals(showing.ShowingTime));
                };

                List<Showing> sameShowings = sameCinemaShowings.FindAll(sameTimeOfDay);


                int availableScreenNumber = sameShowings.Count();
                Debug.WriteLine(availableScreenNumber);
                //Debug.WriteLine($"Available screen number is {availableScreenNumber}");

                Predicate<Showing> movieOnSameDate = (other) =>
                {
                    return other.Movie.Equals(showing.Movie);
                };

                Showing sameshowing = sameShowings.Find(movieOnSameDate);

                if (sameshowing is null)
                {
                    showing.Screen = (cinema.Screens[availableScreenNumber]);
                    showingRepo.Add(showing);
                }
                else
                {
                    // TODO : Vend det her med gruppen
                    /* grundet overlap i odense cinemaxx 2019 12-01 ( 3 ens film, med 3 bookings hver, samtidigt samme biograf. ) 
                     * altså 9 unikke screens for samme biograf samme dag... af den årsag 
                     * er det en upraktisk løsning at tilføje en screen per booking for en sideløbende forestilling
                     * */
                    //sameshowing.Screens.Add(cinema.Screens[availableScreenNumber]);
                }

                // find alle showings for dato
                // find første ledige sal for dato/tid
                // indsæt ledig sal på showing


                
            }

            writer = new StreamWriter(exportFile);
        }
    }
}
