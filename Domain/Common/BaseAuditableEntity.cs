﻿namespace Domain.Common;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime ModifyDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifyBy { get; set; }
}
