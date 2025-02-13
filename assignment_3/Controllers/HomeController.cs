using System.Diagnostics;
using assignment_3.Data;
using Microsoft.AspNetCore.Mvc;
using assignment_3.Models;

namespace assignment_3.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {

        return View();
    }
    
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