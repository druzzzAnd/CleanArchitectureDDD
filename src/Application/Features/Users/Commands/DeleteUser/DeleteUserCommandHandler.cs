using Application.Features.Users.Commands.DeleteUser.Response;
using Application.Interfaces.Providers;
using Mapster;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(
    IUnitOfWorkFactory unitOfWorkFactory)
    : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    public async Task<DeleteUserResponse> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        // create uow
        await using var uow = unitOfWorkFactory.Create();

        // main logic
        var user = uow.UserRepository.GetById(command.UserId)
            ?? throw new Exception($"Не найдено пользователя с Id {command.UserId}");

        uow.UserRepository.Delete(user);

        await uow.SaveChangesAsync();

        return user.Adapt<DeleteUserResponse>();
    }
}
