using System;
using System.Collections.Generic;

namespace UniversitySystem.Core.Models;

public partial class User
{
    public decimal Userid { get; set; }

    public string Fullname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public decimal Roleid { get; set; }

    public virtual Role Role { get; set; } = null!;
}
