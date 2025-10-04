namespace Application.Interfaces.Providers;

public interface IUnitOfWorkFactory
{
    IUnitOfWork Create();
}
