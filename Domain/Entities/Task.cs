using Domain.Common;
namespace Domain.Entities;

public class Task : BaseAuditableEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskState State { get; set; }
    public string Notes { get; set; }
}
