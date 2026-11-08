using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class Sectionschedule
{
    public decimal Scheduleid { get; set; }

    public string Dayofweek { get; set; } = null!;

    public string Starttime { get; set; } = null!;

    public string Endtime { get; set; } = null!;

    public string Roomnumber { get; set; } = null!;

    public decimal Sectionid { get; set; }

    public virtual Section Section { get; set; } = null!;
}
