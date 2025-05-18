namespace _5_1_25_task1.DAL.Models;
public class Department : BaseEntity
{
    [Required, MinLength(3), MaxLength(30)]
    public string Title { get; set; }

    public ICollection<Doctor>? Doctors { get; set; }
}
