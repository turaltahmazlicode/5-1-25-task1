using _5_1_25_task1.DAL;
using _5_1_25_task1.Models;
using _5_1_25_task1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1.Controllers;
public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        IndexViewModel indexViewModel = new IndexViewModel()
        {
            HeaderDoctors = _context.HeaderDoctors.ToList(),
            Services = _context.Services.ToList(),
            Doctors = _context.Doctors.Include(d => d.Department).ToList(),
        };
        return View(indexViewModel);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Service()
    {
        return View();
    }

    public IActionResult Feature()
    {
        return View();
    }

    public IActionResult Team()
    {
        return View();
    }

    public IActionResult Appointment()
    {
        return View();
    }

    public IActionResult Testimonial()
    {
        return View();
    }

    public IActionResult _404()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
}
