using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class Student
{
    public decimal Studentid { get; set; }

    public string Universityid { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal Departmentid { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
