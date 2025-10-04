using Application.Interfaces.Repositories;

namespace Application.Interfaces.Providers;

public interface IUnitOfWork : IAsyncDisposable
{
    IUserRepository UserRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
