using _5_1_25_task1.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace _5_1_25_task1.BL.ViewModels.Admin;
public class DepartmentVM
{
    [Required, MinLength(3), MaxLength(30)]
    public string Title { get; set; }

    public ICollection<Doctor>? Doctors { get; set; }
}
