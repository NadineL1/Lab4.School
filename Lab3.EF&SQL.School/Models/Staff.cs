using System;
using System.Collections.Generic;

namespace Lab4.School.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual StaffRole? Role { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
