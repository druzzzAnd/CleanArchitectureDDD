using Application.Events.Users.CreateUser;
using Application.Features.Users.Commands.CreateUser.Response;
using Application.Interfaces.Providers;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUnitOfWorkFactory unitOfWorkFactory, IMessageBusService messageBusService)
    : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // create uow
        await using var uow = unitOfWorkFactory.Create();

        // main logic
        var user = new User(
            request.CreateUserRequest.Email,
            request.CreateUserRequest.FirstName,
            request.CreateUserRequest.LastName);

        uow.UserRepository.Create(user);

        await uow.SaveChangesAsync();

        // send event into queue
        var createUserEvent = new CreateUserEvent(
            user.Id,
            user.Email,
            user.FirstName,
            user.LastName,
            user.CreatedAt,
            user.UpdatedAt);

        await messageBusService.PublishAsync(createUserEvent);

        return user.Adapt<CreateUserResponse>();
    }
}
