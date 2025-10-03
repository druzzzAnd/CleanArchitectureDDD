using Application.Features.Users.Commands.DeleteUser.Response;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid UserId) : IRequest<DeleteUserResponse>;
