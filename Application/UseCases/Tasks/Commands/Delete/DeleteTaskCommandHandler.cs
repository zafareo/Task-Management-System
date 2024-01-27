using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using MediatR;

namespace Application.UseCases.Tasks.Commands.Delete;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly IApplicationDbContext _context;
    public DeleteTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var ExistingTask = await _context.Tasks.FindAsync(request.Id, cancellationToken);
        if (ExistingTask is null)
            throw new NotFoundException(nameof(Domain.Entities.Task), request.Id);
        _context.Tasks.Remove(ExistingTask);
        return(await _context.SaveChangesAsync(cancellationToken)) > 0;
    }
}
