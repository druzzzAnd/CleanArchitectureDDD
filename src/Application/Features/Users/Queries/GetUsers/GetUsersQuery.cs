using Application.Features.Users.Queries.GetUsers.Response;
using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<List<GetUsersResponse>>;
