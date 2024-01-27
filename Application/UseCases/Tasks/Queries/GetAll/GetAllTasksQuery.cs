using Application.Commons.Models;
using MediatR;

namespace Application.UseCases.Tasks.Queries.GetAll;

public record GetAllTasksQuery : IRequest<PaginatedList<GetAllTasksQueryResponse>>
{
    public string? SearchTerm { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
