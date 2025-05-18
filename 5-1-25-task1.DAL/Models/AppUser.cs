namespace _5_1_25_task1.DAL.Models;
public class AppUser : IdentityUser
{
    [Required, MinLength(2), MaxLength(30)]
    public string Name { get; set; }

    [Required, MinLength(2), MaxLength(30)]
    public string Surname { get; set; }
}
