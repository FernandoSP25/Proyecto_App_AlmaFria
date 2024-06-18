using System;
using System.Collections.Generic;

namespace WebAPI_AlmaFria.Models;

public partial class Login
{
    public int LoginId { get; set; }

    public int UserId { get; set; }

    public DateTime LoginTimestamp { get; set; }

    public DateTime? LogoutTimestamp { get; set; }

    public bool IsConnected { get; set; }

    public string SessionToken { get; set; } = null!;

    public string Ipaddress { get; set; } = null!;

    public string? DeviceInfo { get; set; }

    public virtual Cliente User { get; set; } = null!;
}
