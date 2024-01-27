using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public enum TaskState
{
    [Display(Name = "To-Do")]
    Todo = 1,

    [Display(Name = "In Progress")]
    InProgress = 2,

    [Display(Name = "Completed")]
    Completed = 3
}
