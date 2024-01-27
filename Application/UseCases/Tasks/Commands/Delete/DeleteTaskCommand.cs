using MediatR;

namespace Application.UseCases.Tasks.Commands.Delete;

public record DeleteTaskCommand(Guid Id) : IRequest<bool>;
