using Application.UseCases.Roles.Commands;
using Application.UseCases.Roles.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseApiController
{
    [HttpGet("[action]")]
    public async ValueTask<List<RoleResponse>> GetAllRoles()
   => await Mediator.Send(new GetAllRoleQuery());
    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateRole(CreateRoleCommand command)
  => await Mediator.Send(command);
}
