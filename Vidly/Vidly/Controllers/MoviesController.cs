using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre);
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null) return HttpNotFound();
            return View(movie);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Top Gun" };
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult New()
        {
            var genres = _context.GenreTypes.ToList();

            var viewModel = new MoviesFormViewModel
            {
                GenreTypes = genres
            };
            
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            
            if (movie == null) return HttpNotFound();

            var viewModel = new MoviesFormViewModel
            {
                Movie = movie,
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(MoviesFormViewModel alteredModel)
        {
            var alteredMovie = alteredModel.Movie;

            if (alteredMovie.Id == 0)
            {
                alteredMovie.DateAdded = DateTime.Now;
                _context.Movies.Add(alteredMovie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == alteredMovie.Id);
                movieInDb.Name = alteredMovie.Name;
                movieInDb.GenreId = alteredMovie.GenreId;
                movieInDb.ReleaseDate = alteredMovie.ReleaseDate;
                movieInDb.Stock = alteredMovie.Stock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}