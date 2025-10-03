using Application.Features.Users.Commands.DeleteUser.Response;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetById(command.UserId)
            ?? throw new Exception($"Не найдено пользователя с Id {command.UserId}");

        _userRepository.Delete(user);

        return user.Adapt<DeleteUserResponse>();
    }
}
