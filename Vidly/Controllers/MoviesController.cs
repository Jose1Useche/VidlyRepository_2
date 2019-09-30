using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DataContext;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyContext _context;

        public MoviesController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .OrderBy(m => m.Name);

            return View(movies);
        }

        public ActionResult NewMovie(int id)
        {
            MovieGenres newMovieGenres;

            if(id == 0)
                newMovieGenres = new MovieGenres
                {
                    Genres = _context.Genres.ToList(),
                };
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

                newMovieGenres = new MovieGenres
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movieInDb
                };
            }

            return View(newMovieGenres);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Random");
        }
        
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

    }
}