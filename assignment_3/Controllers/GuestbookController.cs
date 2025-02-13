using System.Diagnostics;
using assignment_3.Data;
using Microsoft.AspNetCore.Mvc;
using assignment_3.Models;

namespace assignment_3.Controllers;

public class GuestbookController : Controller
{
    private readonly ILogger<GuestbookController> _logger;
    private readonly ApplicationDbContext _db;

    public GuestbookController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        //_logger = logger;
        _db = db;
    }

    [HttpGet]
    public IActionResult Index()
    {
        Entry entry = new Entry();
        
        return View(_db.Entry.ToList());
    }
    
    [HttpPost]
    public IActionResult Index(Entry entry)
    {
        _db.Entry.Add(entry);
        _db.SaveChanges();
        return View(_db.Entry.ToList());
    }

    public IActionResult Add()
    {
        return View();
    }
}