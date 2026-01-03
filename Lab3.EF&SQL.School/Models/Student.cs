using System;
using System.Collections.Generic;

namespace Lab4.School.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string PersonalNumber { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public string? PhoneNumber { get; set; }

    public int? ClassId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
