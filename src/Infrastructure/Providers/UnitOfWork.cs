using Application.Interfaces.Providers;
using Application.Interfaces.Repositories;
using Infrastructure.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace Infrastructure.Providers;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgreDbContext _dbContext;
    private readonly IServiceProvider _serviceProvider;
    private readonly ConcurrentDictionary<Type, Lazy<object>> _repositories;
    private bool _disposed = false;

    public UnitOfWork(
        PostgreDbContext dbContextFactory,
        IServiceProvider serviceProvider)
    {
        _dbContext = dbContextFactory;
        _serviceProvider = serviceProvider;
        _repositories = new ConcurrentDictionary<Type, Lazy<object>>();
    }

    private T GetRepository<T>()
        where T : class
    {
        return _repositories.GetOrAdd(typeof(T), type =>
            new Lazy<object>(() => _serviceProvider.GetRequiredService(type)))
            .Value as T;
    }

    public IUserRepository UserRepository => GetRepository<IUserRepository>();

    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            await _dbContext.DisposeAsync();
            _disposed = true;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
