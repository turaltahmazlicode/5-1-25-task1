using _5_1_25_task1.Areas.Admin.ViewModels;
using _5_1_25_task1.DAL;
using _5_1_25_task1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _5_1_25_task1.Areas.Admin.Controllers;
[Area("Admin")]
public class DepartmentController : Controller
{
    private readonly AppDbContext _context;

    public DepartmentController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateDepartment()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(Department department)
    {
        if (!ModelState.IsValid)
            return NotFound();
        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table), "Dashboard");
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
        return RedirectToAction(nameof(Table), "Dashboard");
    }

    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department is null)
            return NotFound();
        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Table), "Dashboard");
    }

    public async Task<IActionResult> AddDoctors(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department is null)
            return NotFound();

        var availableDoctors = await _context.Doctors
            .ToListAsync();

        var model = new AddDoctorsVM
        {
            DepartmentId = department.Id,
            DepartmentTitle = department.Title,
            AvailableDoctors = availableDoctors
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddDoctors(AddDoctorsVM vm)
    {

        var department = await _context.Departments.FindAsync(vm.DepartmentId);
        if (department is null)
            return NotFound();

        if (vm.SelectedDoctorIds.Any())
        {
            var doctors = await _context.Doctors
                                .Where(d => vm.SelectedDoctorIds.Contains(d.Id))
                                .ToListAsync();

            foreach (var doctor in doctors)
                doctor.DepartmentId = department.Id;
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Table), "Dashboard");
    }
}
