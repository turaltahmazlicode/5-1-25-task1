using Microsoft.AspNetCore.Mvc;

namespace _5_1_25_task1.MVC.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
