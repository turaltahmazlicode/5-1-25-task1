using _5_1_25_task1.DAL;
using _5_1_25_task1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _5_1_25_task1.Areas.Admin.Controllers;
[Area("Admin")]
public class DoctorController : Controller
{
    private readonly AppDbContext _context;

    public DoctorController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
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
        if (_context.Departments.Find(doctor.DepartmentId) is null)
            return NotFound();
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table), "Dashboard");
    }

    public async Task<IActionResult> UpdateDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor is null)
            return NotFound();
        return View(nameof(CreateDoctor), doctor);
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
        return RedirectToAction(nameof(Table), "Dashboard");
    }

    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor is null)
            return NotFound();
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table), "Dashboard");
    }
}
