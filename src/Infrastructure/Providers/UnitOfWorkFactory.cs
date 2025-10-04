using Application.Interfaces.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Providers;

public class UnitOfWorkFactory(IServiceProvider serviceProvider) : IUnitOfWorkFactory
{
    public IUnitOfWork Create()
    {
        return serviceProvider.GetRequiredService<IUnitOfWork>();
    }
}
