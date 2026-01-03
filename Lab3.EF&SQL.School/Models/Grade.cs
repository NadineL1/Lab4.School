using System;
using System.Collections.Generic;

namespace Lab4.School.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int GradeValue { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public DateOnly? GradeDate { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}
