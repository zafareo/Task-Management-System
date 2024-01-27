using Application.Commons.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Tasks.Commands.Create;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateTaskCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Task task = _mapper.Map<Domain.Entities.Task>(request);

        await _context.Tasks.AddAsync(task, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}
