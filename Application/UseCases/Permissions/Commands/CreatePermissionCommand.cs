using MediatR;

namespace Application.UseCases.Permissions.Commands;

public class CreatePermissionCommand : IRequest<List<PermissionResponse>>
{
    public string[] Name { get; set; }
}
