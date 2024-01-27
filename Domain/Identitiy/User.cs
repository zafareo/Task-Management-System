﻿using Domain.Common;

namespace Domain.Identitiy;

public class User : BaseAuditableEntity
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Picture { get; set; }
    public virtual ICollection<Role>? Roles { get; set; }
}
