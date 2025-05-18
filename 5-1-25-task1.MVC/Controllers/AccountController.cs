using _5_1_25_task1.BL.ViewModels.Account;
using _5_1_25_task1.DAL.Enums;
using _5_1_25_task1.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace _5_1_25_task1.MVC.Controllers;
public class AccountController : Controller
{
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    #region Register
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        AppUser appUser = new AppUser()
        {
            Name = vm.Name,
            Surname = vm.Surname,
            Email = vm.Email,
            UserName = vm.Username
        };

        var result = await _userManager.CreateAsync(appUser, vm.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(vm);
        }

        return RedirectToAction("Index", "Home");
    }
    #endregion

    #region Login
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM vm, string? ReturnUrl)
    {
        if (!ModelState.IsValid)
            return View(vm);

        AppUser? user = await _userManager.FindByEmailAsync(vm.EmailOrUsername) ??
                        await _userManager.FindByNameAsync(vm.EmailOrUsername);

        if (user is null)
        {
            ModelState.AddModelError("", "Email or password is incorrect");
            return View(vm);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, vm.Remember);

        if (result.IsLockedOut)
        {
            ModelState.AddModelError("", "Your account is locked out. Please try again later.");
            return View(vm);
        }

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Email or password is incorrect");
            return View(vm);
        }

        await _signInManager.SignInAsync(user, vm.Remember);

        if (ReturnUrl is not null)
            return Redirect(ReturnUrl);

        return RedirectToAction("Index", "Home");
    }
    #endregion

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> CreateRoles()
    {
        foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
            await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
        return RedirectToAction("Index", "Home");
    }
}
