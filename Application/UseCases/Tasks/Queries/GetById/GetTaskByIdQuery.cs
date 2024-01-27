using MediatR;

namespace Application.UseCases.Tasks.Queries.GetById;

public record GetTaskByIdQuery(Guid Id) : IRequest<GetTaskByIdQueryRespоnse>;
