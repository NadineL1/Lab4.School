using System;
using System.Collections.Generic;

namespace Lab4.School.Models;

public partial class StaffRole
{
    public int Id { get; set; }

    public string? Rname { get; set; }

    public string? JobDescription { get; set; }

    public int? Salary { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
