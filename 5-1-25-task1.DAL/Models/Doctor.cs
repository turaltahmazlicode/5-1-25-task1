using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace _5_1_25_task1.DAL.Models;
public class Doctor : BaseEntity
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2), MaxLength(40)]
    public string LastName { get; set; }

    public string? ImageUrl { get; set; }

    public int? DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    public Department? Department { get; set; }

    [NotMapped]
    public IFormFile Image { get; set; }
}
