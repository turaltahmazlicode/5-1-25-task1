using _5_1_25_task1.BL.Services.Concretes;
using _5_1_25_task1.DAL.Models;
using _5_1_25_task1.MVC.Helper.Extensions;

namespace _5_1_25_task1.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly DepartmentService _departmentService;
        private readonly DoctorService _doctorService;
        private readonly IWebHostEnvironment _env;

        public DoctorController(DepartmentService departmentService, DoctorService doctorService, IWebHostEnvironment env)
        {
            _departmentService = departmentService;
            _doctorService = doctorService;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Doctor> doctors = _doctorService.GetAll();
            List<Department> departments = _departmentService.GetAll();
            foreach (var doctor in doctors)
                doctor.Department = departments.Find(d => d.Id == doctor.DepartmentId);
            return View(doctors);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _departmentService.GetAll();
                return View(vm);
            }

            if (!vm.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("", "Please select a valid image file.");
                ViewBag.Departments = _departmentService.GetAll();
                return View(vm);
            }

            string fileName = vm.Image.Upload(_env.WebRootPath, "Upload");

            var doctor = new Doctor
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                ImageUrl = fileName,
                DepartmentId = vm.DepartmentId,
            };

            await _doctorService.AddAsync(doctor);
            await _doctorService.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            doctor.Department = await _departmentService.GetByIdAsync(doctor.DepartmentId);
            return View(doctor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            doctor.Department = await _departmentService.GetByIdAsync(doctor.DepartmentId);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var doctor = await _doctorService.GetByIdAsync(id);
                var imgPath = doctor?.ImageUrl;

                _doctorService.Delete(doctor);
                await _doctorService.SaveChangesAsync();

                FileExtensions.DeleteFile(_env.WebRootPath, "Upload", imgPath);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = _doctorService.IsExistById(id);
            //doctor.Doctors = _doctorService.GetAll();
            return View(doctor);
            //return View(new DepartmentVM() { Id = department.Id, Title = department.Title });
        }

        /*        [HttpPost]
                public async Task<IActionResult> Edit(Doctor vm)
                {
                    if (!ModelState.IsValid)
                    {
                        return View(vm);
                    }

                    var doctor = new Doctor
                    {
                        Id = vm.Id,
                        Title = vm.Title,
                    };

                    try
                    {
                        _doctorService.Update(department);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                        return View(vm);
                    }
                    await _doctorService.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
        */

    }
}
