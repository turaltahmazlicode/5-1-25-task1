using _5_1_25_task1.BL.Services.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace _5_1_25_task1.MVC.Areas.Admin.Controllers
{
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

        public IActionResult Index()
        {
            List<Department> departments = _departmentService.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

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
            return View(await _departmentService.GetByIdAsync(id));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _departmentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
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
            var department = _departmentService.IsExistById(id);
            department.Doctors = _doctorService.GetAll();
            return View(department);
            //return View(new DepartmentVM() { Id = department.Id, Title = department.Title });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var department = new Department
            {
                Id = vm.Id,
                Title = vm.Title,
            };

            try
            {
                _departmentService.Update(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vm);
            }
            await _departmentService.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
