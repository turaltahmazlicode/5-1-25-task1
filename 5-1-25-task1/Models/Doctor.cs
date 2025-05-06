namespace _5_1_25_task1.Models;

public class Doctor : BaseModel
{
    public string Image { get; set; }
    public string Fullname { get; set; }
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
