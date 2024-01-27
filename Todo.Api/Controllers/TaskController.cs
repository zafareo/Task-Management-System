using Application.Commons.Models;
using Application.UseCases.Tasks.Commands.Create;
using Application.UseCases.Tasks.Commands.Delete;
using Application.UseCases.Tasks.Commands.Edit;
using Application.UseCases.Tasks.Queries.GetAll;
using Application.UseCases.Tasks.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : BaseApiController
{
    [HttpPost("[action]")]
    public async ValueTask<Guid> CreateTask(CreateTaskCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet("[action]")]
    public async ValueTask<ActionResult<PaginatedList<GetAllTasksQueryResponse>>> GetAllTasks([FromQuery] GetAllTasksQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("[action]")]
    public async ValueTask<GetTaskByIdQueryRespоnse> GetTaskById(Guid Id)
    {
        return await Mediator.Send(new GetTaskByIdQuery(Id));
    }


    [HttpPut("[action]")]
    public async ValueTask<IActionResult> EditTask(EditTaskCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("[action]")]
    public async ValueTask<IActionResult> DeleteTask(DeleteTaskCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
}
