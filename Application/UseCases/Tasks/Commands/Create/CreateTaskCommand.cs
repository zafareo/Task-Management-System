using Domain.Entities;
using MediatR;

namespace Application.UseCases.Tasks.Commands.Create;

public class CreateTaskCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskState State { get; set; }
    public string Notes { get; set; }
}
