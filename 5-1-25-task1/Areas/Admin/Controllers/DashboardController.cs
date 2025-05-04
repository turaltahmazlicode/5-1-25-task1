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

    public IActionResult CreateDoctor()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor(Doctor doctor)
    {
        if (!ModelState.IsValid)
            return NotFound(nameof(Table));
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }

    public async Task<IActionResult> UpdateDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor is null)
            return NotFound();
        return View(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDoctor(Doctor doctor)
    {
        if (!ModelState.IsValid)
            return NotFound();
        if (_context.Departments.Find(doctor.DepartmentId) is null)
            return NotFound();
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }

    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor is null)
            return NotFound();
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }

    public IActionResult CreateDepartment()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(Department department)
    {
        Console.WriteLine("hello");
        if (!ModelState.IsValid)
            return NotFound(nameof(Table));
        Console.WriteLine("hello");
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }

    public async Task<IActionResult> UpdateDepartment(int id)
    {
        var department = await _context.Doctors.FindAsync(id);
        if (department is null)
            return NotFound();
        return View(department);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDepartment(Department department)
    {
        if (!ModelState.IsValid)
            return NotFound();
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }

    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department is null)
            return NotFound();
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }
}