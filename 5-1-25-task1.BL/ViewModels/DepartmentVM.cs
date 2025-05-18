namespace _5_1_25_task1.BL.ViewModels;
public class DepartmentVM
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string Title { get; set; }

    public List<Doctor>? Doctors { get; set; }
    public List<Doctor>? SelectedDoctors { get; set; }
}