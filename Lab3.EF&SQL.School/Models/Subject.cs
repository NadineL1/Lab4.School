using System;
using System.Collections.Generic;

namespace Lab4.School.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? SubjectName { get; set; }

    public int? TeacherId { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Staff? Teacher { get; set; }
}
