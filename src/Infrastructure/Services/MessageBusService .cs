using Application.Interfaces.Services;
using MassTransit;

namespace Infrastructure.Services;

public class MessageBusService(IBus bus) : IMessageBusService
{
    public async Task PublishAsync<TMessage>(TMessage message) where TMessage : class
    {
        await bus.Publish<TMessage>(message);
    }
}
