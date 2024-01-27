using MediatR;

namespace Application.UseCases.Roles.Commands;

public class CreateRoleCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public List<Guid>? PermissionsIds { get; set; }
}
