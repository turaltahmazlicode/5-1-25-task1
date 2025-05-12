
namespace _5_1_25_task1.BL.ViewModels;
public class RegisterVM
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2), MaxLength(40)]
    public string LastName { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    public bool RememberMe { get; set; }
}
