using Application.Features.Users.Queries.GetUserById.Response;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = _userRepository.GetById(query.UserId)
            ?? throw new Exception($"Не найдено пользователя с Id {query.UserId}");

        return user.Adapt<GetUserByIdResponse>();
    }
}
