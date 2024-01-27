using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public enum TaskPriority
{
    [Display(Name = "Low Priority")]
    Low = 1,

    [Display(Name = "Medium Priority")]
    Medium = 2,

    [Display(Name = "High Priority")]
    High = 3
}
