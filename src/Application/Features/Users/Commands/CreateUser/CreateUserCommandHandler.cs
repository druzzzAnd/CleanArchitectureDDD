using Application.Events.Users.CreateUser;
using Application.Features.Users.Commands.CreateUser.Response;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMessageBusService _messageBusService;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IMessageBusService messageBusService)
    {
        _userRepository = userRepository;
        _messageBusService = messageBusService;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // main logic
        var user = new User(
            request.CreateUserRequest.Email,
            request.CreateUserRequest.FirstName,
            request.CreateUserRequest.LastName);

        _userRepository.Create(user);

        // send event into queue
        var createUserEvent = new CreateUserEvent(
            user.Id,
            user.Email,
            user.FirstName,
            user.LastName,
            user.CreatedAt,
            user.UpdatedAt);

        await _messageBusService.PublishAsync(createUserEvent);

        return user.Adapt<CreateUserResponse>();
    }
}
