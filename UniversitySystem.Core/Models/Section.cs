using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class Section
{
    public decimal Sectionid { get; set; }

    public byte Sectionnumber { get; set; }

    public byte Capacity { get; set; }

    public decimal Courseid { get; set; }

    public decimal Instructorid { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual ICollection<Sectionschedule> Sectionschedules { get; set; } = new List<Sectionschedule>();
}
