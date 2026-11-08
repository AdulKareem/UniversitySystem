using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class Department
{
    public decimal Departmentid { get; set; }

    public string Departmentname { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
