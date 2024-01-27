using Application.Commons.Models;
using MediatR;

namespace Application.UseCases.Permissions.Queries;

public class GetAllPermissionQuery : IRequest<PaginatedList<PermissionResponse>>
{
    public string? SearchingText { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
