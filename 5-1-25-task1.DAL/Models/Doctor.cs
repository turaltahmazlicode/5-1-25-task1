﻿namespace _5_1_25_task1.DAL.Models;
public class Doctor : BaseEntity
{
    [Required, MinLength(2), MaxLength(30)]
    public string Name { get; set; }


    [Required, MinLength(2), MaxLength(30)]
    public string Surname { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? InstagramUrl { get; set; }

    public int? DepartmentId { get; set; }

    public Department? Department { get; set; }
}
