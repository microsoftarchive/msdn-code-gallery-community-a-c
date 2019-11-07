using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using CinemaPlex.Models;
using CinemaPlex.Data;
using System.Data.SqlClient;
using CinemaPlex;

namespace CinemaPlex.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            ViewData["MovieId"] = id;
            return View();
        }

        public ActionResult Search(string movieName)
        {
            //Finds movie results based on movieName or Cinema Name.
            Console.WriteLine(movieName);
            List<MovieModel> movies = Program.data.getMoviesbyName(movieName);
            if (movies != null && movies.Count > 0) //Found Movies based on this search string.
            {
                ViewData["MoviesList"] = movies;
            }
            else //Couldn't find any movies based on the search string provided, so we will search if any cinemas match.
            {
                List<CinemaModel> cinemas = Program.data.getCinemasByName(movieName);
                if (cinemas != null && cinemas.Count > 0)
                {
                    List<MovieModel> allMovies = new List<MovieModel>();
                    foreach(var cinema in cinemas)
                    {
                        var sessions = Program.data.getSessionsbyCinema(cinema.CineplexID);
                        foreach(var session in sessions)
                        {
                            var movie = Program.data.getMovie(session.MovieID);
                            allMovies.Add(movie);
                        }
                    }
                    ViewData["MoviesList"] = allMovies;
                }
            }
            return View();
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}