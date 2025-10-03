using Application.Features.Users.Commands.CreateUser.Response;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            request.CreateUserRequest.Email,
            request.CreateUserRequest.FirstName,
            request.CreateUserRequest.LastName);

        _userRepository.Create(user);

        return user.Adapt<CreateUserResponse>();
    }
}
