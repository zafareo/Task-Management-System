using Application.UseCases.Users.Response;
using MediatR;

namespace Application.UseCases.Users.Queries.GetById;

public record GetUserByIdQuery(Guid Id) : IRequest<UserResponse>;
