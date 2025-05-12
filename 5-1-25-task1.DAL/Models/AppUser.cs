using System.ComponentModel.DataAnnotations;

namespace _5_1_25_task1.DAL.Models;
public class AppUser : IdentityUser
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2), MaxLength(40)]
    public string LastName { get; set; }
}
