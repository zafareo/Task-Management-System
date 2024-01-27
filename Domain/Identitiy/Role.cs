using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Identitiy;

public class Role : BaseAuditableEntity
{
    public string Name { get; set; }
    public virtual ICollection<Permission> Permissions { get; set; }
    [JsonIgnore]
    public virtual ICollection<User>? Users { get; set; }
}
