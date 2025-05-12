namespace _5_1_25_task1.DAL.Models;
public class Department : BaseEntity
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string Title { get; set; }

    public List<Department>? Departments { get; set; }
}
