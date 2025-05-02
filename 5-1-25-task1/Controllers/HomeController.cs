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
        if (_context.HeaderDoctors.Count() == 0)
        {
            _context.HeaderDoctors.Add(new HeaderDoctor() { Department = "Cardiology", Image = "carousel-1.jpg", });
            _context.HeaderDoctors.Add(new HeaderDoctor() { Department = "Neurology", Image = "carousel-2.jpg", });
            _context.HeaderDoctors.Add(new HeaderDoctor() { Department = "Pulmonary", Image = "carousel-3.jpg", });
            _context.SaveChanges();
        }
        if (_context.Services.Count() == 0)
        {
            _context.Services.Add(new Service() { Icon = "heartbeat", Title = "Cardiology", ShortDescription = "Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet." });
            _context.Services.Add(new Service() { Icon = "x-ray", Title = "Pulmonary", ShortDescription = "Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet." });
            _context.Services.Add(new Service() { Icon = "brain", Title = "Neurology", ShortDescription = "Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet." });
            _context.Services.Add(new Service() { Icon = "wheelchair", Title = "Orthopedics", ShortDescription = "Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet." });
            _context.Services.Add(new Service() { Icon = "tooth", Title = "Dental Surgery", ShortDescription = "Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet." });
            _context.Services.Add(new Service() { Icon = "vials", Title = "Laboratory", ShortDescription = "Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet." });
            _context.SaveChanges();
        }
        if (_context.Departments.Count() == 0)
        {
            _context.Departments.Add(new Department() { Title = "Cardiology" });
            _context.Departments.Add(new Department() { Title = "Pulmonary" });
            _context.Departments.Add(new Department() { Title = "Neurology" });
            _context.SaveChanges();
        }
        if (_context.Doctors.Count() == 0)
        {
            _context.Doctors.Add(new Doctor() { Image = "team-1.jpg", Fullname = "Jesse Pinkman", DepartmentId = 1 });
            _context.Doctors.Add(new Doctor() { Image = "team-2.jpg", Fullname = "Walter White", DepartmentId = 3 });
            _context.Doctors.Add(new Doctor() { Image = "team-3.jpg", Fullname = "Saul Goodman", DepartmentId = 1 });
            _context.Doctors.Add(new Doctor() { Image = "team-4.jpg", Fullname = "Mike Ehrmantraut", DepartmentId = 2 });
            _context.SaveChanges();
        }
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
