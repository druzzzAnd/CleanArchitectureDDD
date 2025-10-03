using Application.Features.Users.Commands.CreateUser.Request;
using Application.Features.Users.Commands.CreateUser.Response;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserRequest CreateUserRequest) : IRequest<CreateUserResponse>;
