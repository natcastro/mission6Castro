using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers;
// Mission 6: Handles general site navigation pages
public class HomeController : Controller
{
    // Mission 6 Requirement:
    // Displays the "Get to Know Joel" page
    public IActionResult GetToKnowJoel() // I  added this the rest came with the tamplate 
    {
        return View();
    }
    
    public IActionResult Index()
    {
        return View();
    }
    // Default template page (not required for mission but included by template)
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
