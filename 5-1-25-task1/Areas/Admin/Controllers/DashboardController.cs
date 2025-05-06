using _5_1_25_task1.DAL;
using _5_1_25_task1.Models;
using _5_1_25_task1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace _5_1_25_task1.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Table()
    {
        AdminIndexViewModel vm = new AdminIndexViewModel()
        {
            Doctors = await _context.Doctors.Include(c => c.Department).ToListAsync(),
            Departments = await _context.Departments.ToListAsync(),
        };
        return View(vm);
    }


}