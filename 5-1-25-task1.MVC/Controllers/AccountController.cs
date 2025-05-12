
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace _5_1_25_task1.MVC.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public AccountController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM vm)
    {
        if (!ModelState.IsValid)
            return View();

        AppUser user = new AppUser()
        {
            Email = vm.Email,
            FirstName = vm.FirstName,
            LastName = vm.LastName,
            UserName = vm.Username,
        };
        var result = await _userManager.CreateAsync(user, vm.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return View(vm);
    }

    public IActionResult Login()
    {
        return View();
    }
}
