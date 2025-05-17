namespace _5_1_25_task1.BL.ViewModels;
public class DepartmentVM
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string Title { get; set; }

    public List<SelectListItem>? Doctors { get; set; }
}