using _5_1_25_task1.BL.Services.Concretes;
using _5_1_25_task1.BL.ViewModels.Admin;
using _5_1_25_task1.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace _5_1_25_task1.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DepartmentController : Controller
{
    public DepartmentController(DepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    private readonly DepartmentService _departmentService;

    #region Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        Department department = new()
        {
            Title = vm.Title
        };

        await _departmentService.CreateAsync(department);

        await _departmentService.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Read
    public async Task<IActionResult> Index()
    {
        return View(await _departmentService.GetAll(false, "Doctors"));
    }

    public async Task<IActionResult> Details(int id)
    {
        Department department;
        try
        {
            department = await _departmentService.GetIfExist(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        DepartmentVM vm = new()
        {
            Title = department.Title,
        };

        ViewBag.Id = id;
        return View(vm);
    }
    #endregion

    #region Update
    public async Task<IActionResult> Update(int id)
    {
        Department department;
        try
        {
            department = await _departmentService.GetIfExist(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        DepartmentVM vm = new()
        {
            Title = department.Title,
        };

        ViewBag.Id = id;
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, DepartmentVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        Department department = new()
        {
            Id = id,
            Title = vm.Title,
        };

        try
        {
            await _departmentService.Update(department);
            await _departmentService.SaveChangesAsync();

            return View();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    #endregion

    #region Delete
    public async Task<IActionResult> Delete(int id)
    {
        Department department;
        try
        {
            department = await _departmentService.GetIfExist(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        DepartmentVM vm = new()
        {
            Title = department.Title,
        };

        ViewBag.Id = id;
        return View(vm);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
        Department department = new()
        {
            Id = id,
        };

        try
        {
            await _departmentService.Delete(department);
            await _departmentService.SaveChangesAsync();

            return View();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    #endregion
}
