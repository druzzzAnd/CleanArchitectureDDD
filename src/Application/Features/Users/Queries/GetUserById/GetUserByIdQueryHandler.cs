using Application.Features.Users.Queries.GetUserById.Response;
using Application.Interfaces.Providers;
using Mapster;
using MediatR;

namespace Application.Features.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(IUnitOfWorkFactory unitOfWorkFactory)
    : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
{
    public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        // create uow
        await using var uow = unitOfWorkFactory.Create();

        // main logic
        var user = uow.UserRepository.GetById(query.UserId)
            ?? throw new Exception($"Не найдено пользователя с Id {query.UserId}");

        return user.Adapt<GetUserByIdResponse>();
    }
}
