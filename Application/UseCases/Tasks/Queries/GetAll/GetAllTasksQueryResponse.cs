using Domain.Entities;

namespace Application.UseCases.Tasks.Queries.GetAll;

public class GetAllTasksQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskState State { get; set; }
    public string Notes { get; set; }
}
