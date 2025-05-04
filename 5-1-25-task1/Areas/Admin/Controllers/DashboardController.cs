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
        };
        return View(vm);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Doctor doctor)
    {
        if (!ModelState.IsValid)
            return NotFound(nameof(Table));
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }

    public async Task<IActionResult> Update(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor is null)
            return NotFound();
        return View(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Doctor doctor)
    {
        if (!ModelState.IsValid)
            return NotFound();
        if (_context.Departments.Find(doctor.DepartmentId) is null)
            return NotFound();
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor is null)
            return NotFound();
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }
}