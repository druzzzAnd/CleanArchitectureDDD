using Application.Features.Users.Commands.UpdateUser.Response;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetById(request.UserId)
            ?? throw new Exception($"Не найден пользователь с Id {request.UserId}");

        user.Email = request.UpdateUserRequest.Email;
        user.FirstName = request.UpdateUserRequest.FirstName;
        user.LastName = request.UpdateUserRequest.LastName;

        _userRepository.Update(user);

        return user.Adapt<UpdateUserResponse>();
    }
}
