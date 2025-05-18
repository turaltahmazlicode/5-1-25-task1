using _5_1_25_task1.BL.Services.Concretes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace _5_1_25_task1.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DepartmentController : Controller
{
    public DepartmentController(DepartmentService departmentService, DoctorService doctorService)
    {
        _departmentService = departmentService;
        _doctorService = doctorService;
    }
    private readonly DepartmentService _departmentService;
    private readonly DoctorService _doctorService;

    #region Create
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentVM vm)
    {
        if (!ModelState.IsValid)
        {
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
    #endregion

    #region Read
    public async Task<IActionResult> Index()
    {
        List<Department> departments = await _departmentService.GetAll();
        return View(departments);
    }
    #endregion

    #region Update
    public async Task<IActionResult> Edit(int id)
    {
        var department = await _departmentService.GetByIdAsync(id, false, "Doctors");
        DepartmentVM vm = new()
        {
            Title = department.Title,
            Doctors = await _doctorService.GetAll(),
            SelectedDoctors = department.Doctors
        };
        return View(vm);
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
    #endregion

    #region Delete
    public async Task<IActionResult> Delete(int id)
    {
        return View(await _departmentService.GetByIdAsync(id));
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
        //try
        {
            var department = await _departmentService.GetByIdAsync(id);

            await _departmentService.Delete(department);

            await _departmentService.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    return View(id);
        //}
    }

    #endregion

    public async Task<IActionResult> Details(int id)
    {
        return View(await _departmentService.GetByIdAsync(id, false, "Doctors"));
    }

}
