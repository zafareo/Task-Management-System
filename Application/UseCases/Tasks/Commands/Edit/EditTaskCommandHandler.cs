using Application.Commons.Exceptions;
using Application.Commons.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Tasks.Commands.Edit;

public class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public EditTaskCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EditTaskCommand request, CancellationToken cancellationToken)
    {
        var ExistingTask = await _context.Tasks.FindAsync(request.Id, cancellationToken);
        //_mapper.Map(request, ExistingTask);
        if (ExistingTask is null)
            throw new NotFoundException(nameof(Domain.Entities.Task), request.Id);
        ExistingTask.Title = request.Title;
        ExistingTask.Description = request.Description;
        ExistingTask.DueDate = request.DueDate;
        ExistingTask.Priority = request.Priority;
        ExistingTask.State = request.State;
        ExistingTask.Notes = request.Notes;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
