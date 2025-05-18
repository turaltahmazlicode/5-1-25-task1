using System.ComponentModel.DataAnnotations;

namespace _5_1_25_task1.BL.ViewModels.Account;
public class LoginVM
{
    [Required]
    public string EmailOrUsername { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember Me")]
    public bool Remember { get; set; } = false;
}
