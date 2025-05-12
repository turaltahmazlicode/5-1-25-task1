namespace _5_1_25_task1.BL.ViewModels;
public class DepartmentVM : BaseEntity
{
    [Required]
    [MinLength(2), MaxLength(30)]
    public string Title { get; set; }
}