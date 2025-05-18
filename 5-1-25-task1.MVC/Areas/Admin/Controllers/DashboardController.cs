using Microsoft.AspNetCore.Authorization;

namespace _5_1_25_task1.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles ="Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
