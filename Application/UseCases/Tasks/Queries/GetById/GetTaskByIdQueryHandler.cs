using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Tasks.Queries.GetById;

public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, GetTaskByIdQueryRespоnse>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;
    public GetTaskByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
         _context = context;
        _mapper = mapper;
    }
    public async Task<GetTaskByIdQueryRespоnse> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.Task? task = await _context.Tasks.FindAsync(request.Id);
        if (task is null)
            throw new NotFoundException(nameof(Domain.Entities.Task), request.Id);
        return _mapper.Map<GetTaskByIdQueryRespоnse>(task);
    }
}
