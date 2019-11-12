using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CinemaPlex.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace CinemaPlex.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<SessionModel> SessionModel { get; set; }
    }
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }

        public DbSet<SessionModel> SessionModel { get; set; }
        public DbSet<MovieModel> MovieModel { get; set; }
        public DbSet<CinemaModel> CinemaModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SessionModel>().ToTable("Sessions");
            modelBuilder.Entity<MovieModel>().ToTable("Movies");
            modelBuilder.Entity<CinemaModel>().ToTable("Cineplex");
        }
    }
    public class DBConnection
    {
        private List<List<string>> GetData(string table)
        {
            SqlConnection myConnection = new SqlConnection("user id=jonathan;" +
<<<<<<< HEAD
                                                           "password=;" +
                                                           "server=test.database.windows.net;" +
=======
                                                           "password=Sarpesarpe123;" +
                                                           "server=webdevcinema.database.windows.net;" +
>>>>>>> d2759e5ca7591045760af98f06a0621de2dbd255
                                                           "Trusted_Connection=False;" +
                                                           "database=webdev-cinema; " +
                                                           "connection timeout=30");

            List<List<string>> myData = new List<List<string>>();
            using (myConnection)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM " + table))
                {
                    SqlDataReader reader;
                    cmd.Connection = myConnection;

                    myConnection.Open();
                    reader = cmd.ExecuteReader();
                    int count = 0;
                    while (reader.Read())
                    {
                        List<string> columnData = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var value = reader[i].ToString();
                            columnData.Add(value);
                        }
                        myData.Add(columnData);
                        count++;
                    }
                    myConnection.Close();
                }
            }
            return myData;
        }
        public List<MovieModel> getMovies()
        {
            var data = GetData("Movies");
            List<MovieModel> Movies = new List<MovieModel>();
            int count = 1;
            foreach (var item in data)
            {
                MovieModel details = new MovieModel()
                {
                    MovieId = count++,
                    MovieLogo = item[1],
                    Title = item[2],
                    Description = item[3],
                    Director = item[4],
                    MainCast = item[5],
                    Classification = item[6],
                    ReleaseDate = item[7],
                    RunningTime = item[8]
                };
                Movies.Add(details);
            }

            return Movies;
        }
        public List<CinemaModel> getCinemas()
        {
            var data = GetData("Cineplex");
            List<CinemaModel> Cinemas = new List<CinemaModel>();
            int count = 1;
            foreach (var item in data)
            {
                CinemaModel details = new CinemaModel()
                {
                    CineplexID = count++,
                    Location = item[1],
                    ShortDescription = item[2],
                    LongDescription = item[3],
                    Address = item[4],
                };
                Cinemas.Add(details);
            }

            return Cinemas;
        }
        public List<SessionModel> getSessions()
        {
            var data = GetData("MoviesRunning");
            List<SessionModel> Sessions = new List<SessionModel>();
            int count = 1;
            foreach (var item in data)
            {
                SessionModel details = new SessionModel()
                {
                    SessionID = count++,
                    CineplexID = Convert.ToInt32(item[0]),
                    MovieID = Convert.ToInt32(item[1]),
                    TimeRunning = TimeSpan.Parse(item[2]),
                    BookingCapacity = Convert.ToDouble(item[3]),
                    BookedCapacity = Convert.ToDouble(item[4]),
                };
                Sessions.Add(details);
            }
            return Sessions;
        }
    }
    public class AllData
    {
        public List<MovieModel> Movies = new List<MovieModel>();
        public List<CinemaModel> Cinemas = new List<CinemaModel>();
        public List<SessionModel> Sessions = new List<SessionModel>();
        public AllData()
        {
            DBConnection db = new DBConnection();
            Movies = db.getMovies();
            Cinemas = db.getCinemas();
            Sessions = db.getSessions();
        }
        public SessionModel getSession(int id)
        {
            return Sessions.Find(x => x.SessionID == id);
        }
        public List<SessionModel> getSessionsbyMovie(int id)
        {
            List<SessionModel> results = Sessions.FindAll(
                delegate (SessionModel sesh)
                {
                    return sesh.MovieID == id;
                }
            );
            if (results.Count != 0)
            {
                return results;
            }
            else
            {
                return null;
            }
        }
        public List<SessionModel> getSessionsbyCinema(int id)
        {
            List<SessionModel> results = Sessions.FindAll(
                delegate (SessionModel sesh)
                {
                    return sesh.CineplexID == id;
                }
            );
            if (results.Count != 0)
            {
                return results;
            }
            else
            {
                return null;
            }
        }

        public MovieModel getMovie(int id)
        {
            return Movies.Find(x => x.MovieId == id);
        }
        public List<MovieModel> getMoviesbyName(string name)
        {
            return Movies.FindAll(x => x.Title.Contains(name));
        }
        public CinemaModel getCinema(int id)
        {
            return Cinemas.Find(x => x.CineplexID == id);
        }
        public List<CinemaModel> getCinemasByName(string name)
        {
            return Cinemas.FindAll(x => x.Location.Contains(name));
        }
        public CinemaModel getCinemaByName(string name)
        {
            return Cinemas.Find(x => x.Location.Contains(name));
        }
    }
}
