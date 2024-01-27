using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using Application.Commons.Models;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Tasks.Queries.GetAll;

public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, PaginatedList<GetAllTasksQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetAllTasksQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PaginatedList<GetAllTasksQueryResponse>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var pageSize = request.PageSize;
        var pageNumber = request.PageNumber;
        var search = request.SearchTerm?.Trim();
        var tasks = _context.Tasks.AsQueryable();
        if (!string.IsNullOrEmpty(search))
        {
            tasks = tasks.Where(t => t.Title.ToLower().Contains(search.ToLower()) || t.Description.ToLower().Contains(search.ToLower()));
        }
        if (tasks is null || tasks.Count() <= 0)
            throw new NotFoundException(nameof(Domain.Entities.Task), search);

        var paginatedTasks = await PaginatedList<Domain.Entities.Task>.CreateAsync(tasks, pageNumber, pageSize);
        var clientResponses = _mapper.Map<List<GetAllTasksQueryResponse>>(paginatedTasks.Items);
        var result = new PaginatedList<GetAllTasksQueryResponse>(clientResponses, paginatedTasks.TotalCount, request.PageNumber, request.PageSize);
        return result;
    }
}
