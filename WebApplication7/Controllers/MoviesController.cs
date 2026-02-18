using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieAppcContex _context;

        public MoviesController(MovieAppcContex temp)
        {
            _context = temp;
        }

        // LIST (your view name is listmovie.cshtml)
        [HttpGet]
        public IActionResult ListMovie()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            return View("ListMovie", movies);
        }

        // ADD (GET)
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(new Movie());
        }

        // ADD (POST)
        [HttpPost]
        public IActionResult Add(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return RedirectToAction("ListMovie");
            }

            // repopulate dropdown on validation error
            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(response);
        }

        // EDIT (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();

            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(movie);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Movie updated)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(updated);
                _context.SaveChanges();
                return RedirectToAction("ListMovie");
            }

            ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
            return View(updated);
        }

        // DELETE (GET confirm)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Category)
                .SingleOrDefault(m => m.MovieId == id);

            if (movie == null) return NotFound();

            return View(movie);
        }

        // DELETE (POST confirm)
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }

            return RedirectToAction("ListMovie");
        }
    }
}