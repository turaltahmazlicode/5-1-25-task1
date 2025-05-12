using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5_1_25_task1.DAL.Models;
public class DoctorVM
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2), MaxLength(40)]
    public string LastName { get; set; }

    [Required]
    public Department Department { get; set; }

    [Required]
    public IFormFile Image { get; set; }
}
