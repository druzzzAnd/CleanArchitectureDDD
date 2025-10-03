using Application.Features.Users.Queries.GetUsers.Response;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUsersResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<GetUsersResponse>?> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAll();

        return users.Adapt<List<GetUsersResponse>>();
    }
}
