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

                if (cinemas is null || !cinemas.Contains(cinema))
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

                if(movies is null || !movies.Contains(movie))
                {
                    MovieRepo.Add(movie);
                }

                Showing showing = new Showing();
                showing.ShowingTime = DateTime.Parse(strings[2]);


                // TODO : showing.Movie may potentially point to a different instance than the one stored in the repository
                showing.Movie = movie;
                showing.Screens.Add(cinema.Screens.FirstOrDefault());

                showingRepo = ShowingRepository.GetInstance();
                List<Showing> showings = showingRepo.GetAll();

                Predicate<Showing> showingSameData = (Showing other) =>
                {
                    
                    return showing.Equals(other);
                };

                Showing sameShowing = showings.Find(showingSameData);


                if (sameShowing != null)
                {
                    //Debug.WriteLine("Sameshowing found!!!!");
                    int currentScreenAmount = sameShowing.Screens.Count;

                    // Add screen with at index of count of current screns
                    sameShowing.Screens.Add(cinema.Screens[sameShowing.Screens.Count]);
                    //Debug.WriteLine(cinema.Screens.Count);


                    // TODO : I think this code is fucked? 
                    
                    Debug.WriteLine($"Sameshowing found! New screen count : {sameShowing.Screens.Count} for {sameShowing.Movie.Title} at {sameShowing.ShowingTime.ToString()}");
                }
                else
                {
                    //Debug.WriteLine("No match found");
                    showing.Screens.Add(cinema.Screens.FirstOrDefault());
                    showingRepo.Add(showing);
                    //Debug.WriteLine(showingRepo.GetAll().Count);
                }
                

                

                //Debug.WriteLine($"{sameTimeShowings.Count} Counts");





            }

            //foreach(var cinema in CinemaRepo.GetAll())
            //{
            //    Debug.WriteLine($"{cinema.Name}:name, {cinema.CityName}:cityName");
            //}

            //foreach(var movie in MovieRepo.GetAll())
            //{
            //    Debug.WriteLine(movie.ToString());
            //}

            writer = new StreamWriter(exportFile);
        }
    }
}
