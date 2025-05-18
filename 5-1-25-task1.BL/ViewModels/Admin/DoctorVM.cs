using _5_1_25_task1.DAL.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace _5_1_25_task1.BL.ViewModels.Admin;
public class DoctorVM
{
    [Required, MinLength(2), MaxLength(30)]
    public string Name { get; set; }


    [Required, MinLength(2), MaxLength(30)]
    public string Surname { get; set; }

    [Required]
    public IFormFile Image { get; set; }

    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? InstagramUrl { get; set; }

    public int? DepartmentId { get; set; }

    public Department? Department { get; set; }
}
