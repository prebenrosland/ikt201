using assignment_4.Data;
using assignment_4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace assignment_4.Controllers;

public class BlogController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    
    public BlogController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _db = db;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View(_db.BlogPosts.ToList());
    }
    
    // GET
    [HttpGet]
    [Authorize]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(BlogPost blogPost)
    {
        var currentUser = await _userManager.GetUserAsync(User);
        string timeStamp = DateTime.Now.ToShortDateString();
        blogPost.Timestamp = timeStamp;
        blogPost.Author = User.Identity?.Name;
        blogPost.Nickname = currentUser.Nickname;
        _db.BlogPosts.Add(blogPost);
        _db.SaveChanges();
        return RedirectToAction("Index", "Blog");
    }
    
    [Authorize]
    public IActionResult Edit(int postId)
    {
        var existingPost = _db.BlogPosts.Find(postId);
        if (User.Identity?.Name != existingPost.Author)
        {
            return RedirectToAction("Index", "Blog");
        }
        return View(existingPost);
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult Edit(int postId, BlogPost updatedPost)
    {
        var currentPost = _db.BlogPosts.Find(postId);

        if (User.Identity?.Name == currentPost.Author)
        {
            updatedPost.Author = currentPost.Author;
            currentPost.Title = updatedPost.Title;
            currentPost.Content = updatedPost.Content;
            currentPost.Summary = updatedPost.Summary;

            _db.SaveChanges();
        }
        else
        {
  
        }
    
        return RedirectToAction("Index", "Blog");
    }
}