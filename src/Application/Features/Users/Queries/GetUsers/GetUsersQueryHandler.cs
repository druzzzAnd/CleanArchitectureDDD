using Application.Features.Users.Queries.GetUsers.Response;
using Application.Interfaces.Providers;
using Mapster;
using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUnitOfWorkFactory unitOfWorkFactory)
    : IRequestHandler<GetUsersQuery, List<GetUsersResponse>>
{
    public async Task<List<GetUsersResponse>?> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        // create uow
        await using var uow = unitOfWorkFactory.Create();

        // main logic
        var users = uow.UserRepository.GetAll();

        return users.Adapt<List<GetUsersResponse>>();
    }
}
