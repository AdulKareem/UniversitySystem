using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class Instructor
{
    public decimal Instructorid { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal Departmentid { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
