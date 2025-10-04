using Application.Features.Users.Commands.UpdateUser.Response;
using Application.Interfaces.Providers;
using Mapster;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IUnitOfWorkFactory unitOfWorkFactory)
    : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // create uow
        await using var uow = unitOfWorkFactory.Create();

        // main logic
        var user = uow.UserRepository.GetById(request.UserId)
            ?? throw new Exception($"Не найден пользователь с Id {request.UserId}");

        user.Email = request.UpdateUserRequest.Email;
        user.FirstName = request.UpdateUserRequest.FirstName;
        user.LastName = request.UpdateUserRequest.LastName;

        uow.UserRepository.Update(user);

        await uow.SaveChangesAsync();

        user = uow.UserRepository.GetById(request.UserId)
            ?? throw new Exception($"Не найден пользователь с Id {request.UserId}");

        return user.Adapt<UpdateUserResponse>();
    }
}
