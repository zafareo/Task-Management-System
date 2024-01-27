using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Identitiy;

public class Permission : BaseAuditableEntity
{
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Role>? Roles { get; set; }
}
