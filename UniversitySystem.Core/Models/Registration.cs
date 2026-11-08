using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class Registration
{
    public decimal Registrationid { get; set; }

    public DateTime Registrationdate { get; set; }

    public string Registrationstatus { get; set; } = null!;

    public decimal Studentid { get; set; }

    public decimal Sectionid { get; set; }

    public virtual Section Section { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
