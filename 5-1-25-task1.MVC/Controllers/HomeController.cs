namespace _5_1_25_task1.MVC.Controllers;

public class HomeController : Controller
{
    //private readonly NonGenericService _nonGenericService;
    //public HomeController(NonGenericService nonGenericService)
    //{
    //    _nonGenericService = _nonGenericService;
    //}

    public IActionResult Index()
    {
        return View();
    }
}
