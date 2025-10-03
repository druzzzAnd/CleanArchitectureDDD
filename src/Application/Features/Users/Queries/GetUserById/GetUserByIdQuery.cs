using Application.Features.Users.Queries.GetUserById.Response;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IRequest<GetUserByIdResponse>;
