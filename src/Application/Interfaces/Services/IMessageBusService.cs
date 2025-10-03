namespace Application.Interfaces.Services;

public interface IMessageBusService
{
    Task PublishAsync<TMessage>(TMessage message) where TMessage : class;
}
