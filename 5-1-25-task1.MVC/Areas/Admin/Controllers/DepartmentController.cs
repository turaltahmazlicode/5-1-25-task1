using _5_1_25_task1.BL.Services.Concretes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace _5_1_25_task1.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DepartmentController : Controller
{
    private readonly DepartmentService _departmentService;
    private readonly DoctorService _doctorService;

    public DepartmentController(DepartmentService departmentService, DoctorService doctorService)
    {
        _departmentService = departmentService;
        _doctorService = doctorService;
    }

    public async Task<IActionResult> Index()
    {
        List<Department> departments = await _departmentService.GetAll();
        return View(departments);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Doctors = await _doctorService.GetAll();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentVM vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Doctors = await _doctorService.GetAll();
            return View(vm);
        }

        var department = new Department
        {
            Title = vm.Title,
        };

        await _departmentService.AddAsync(department);
        await _departmentService.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        return View(await _departmentService.GetByIdAsync(id, false, "Doctors"));
    }

    public async Task<IActionResult> Delete(int id)
    {
        return View(await _departmentService.GetByIdAsync(id));
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
        try
        {
            _departmentService.Delete(await _departmentService.GetByIdAsync(id));
            await _departmentService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        Department department = await _departmentService.GetByIdAsync(id, true, "Doctors");
        return View(department);


        //bütün doctorlar çıxsın amma selectedler qalsın


        //return View(new DepartmentVM() { Id = department.Id, Title = department.Title });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Department department)
    {
        if (!ModelState.IsValid)
            return View(department);

        try
        {
            //var doctors = await _doctorService.GetAll();

            var dp = await _departmentService.GetByIdAsync(department.Id);


            await _departmentService.Update(department);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(department);
        }
        await _departmentService.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }


}
