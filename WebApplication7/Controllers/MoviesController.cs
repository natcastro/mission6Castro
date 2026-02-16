
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
// Mission 6: Handles movie form submission and database storage
namespace WebApplication7.Controllers
{
    public class MoviesController : Controller
    {
        private MovieAppcContex _context;
        // Dependency Injection of DbContext
        public MoviesController(MovieAppcContex temp)
        {
            _context = temp;
        }
// GET: Displays empty movie form
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Saves movie to SQLite database
        [HttpPost]
        public IActionResult Add(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            // If validation fails, return form with errors
            return View(response);
        }
    }
} 
