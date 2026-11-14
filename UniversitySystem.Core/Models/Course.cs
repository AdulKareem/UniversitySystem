//using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class Course
{
    public decimal Courseid { get; set; }

    public string Coursecode { get; set; } = null!;

    public string Coursename { get; set; } = null!;

    public string? Coursedescription { get; set; }

    public int Credithours { get; set; }

    public int? Isfeatured { get; set; }

    public decimal Departmentid { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
