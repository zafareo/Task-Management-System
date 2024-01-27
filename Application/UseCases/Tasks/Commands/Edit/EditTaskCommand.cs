using Domain.Entities;
using MediatR;

namespace Application.UseCases.Tasks.Commands.Edit;

public class EditTaskCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskState State { get; set; }
    public string Notes { get; set; }
}
