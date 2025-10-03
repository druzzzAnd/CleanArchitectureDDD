using Application.Features.Users.Commands.UpdateUser.Request;
using Application.Features.Users.Commands.UpdateUser.Response;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public record UpdateUserCommand(Guid UserId, UpdateUserRequest UpdateUserRequest) : IRequest<UpdateUserResponse>;
