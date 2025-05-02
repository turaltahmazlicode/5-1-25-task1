
namespace _5_1_25_task1.Models;

public class Department : BaseModel
{
    public string Title { get; set; }
    public ICollection<Doctor> Doctors { get; set; }
}
