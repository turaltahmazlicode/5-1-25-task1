using _5_1_25_task1.Models;

namespace _5_1_25_task1.Areas.Admin.ViewModels;

public class AddDoctorsVM
{
    public int DepartmentId { get; set; }
    public string DepartmentTitle { get; set; }
    public List<int> SelectedDoctorIds { get; set; } = new();
    public IEnumerable<Doctor> AvailableDoctors { get; set; } = new List<Doctor>();
}

