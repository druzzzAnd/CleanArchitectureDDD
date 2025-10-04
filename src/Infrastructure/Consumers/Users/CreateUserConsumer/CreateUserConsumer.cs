using Application.Events.Users.CreateUser;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Consumers.Users.CreateUserConsumer;

public class CreateUserConsumer(ILogger<CreateUserConsumer> logger) : IConsumer<CreateUserEvent>
{
    public async Task Consume(ConsumeContext<CreateUserEvent> context)
    {
        var message = context.Message;

        logger.LogInformation("[CONSUMER] ✅ Получено событие создания пользователя: \n\t" +
                              $"ID: {message.Id}, \n\t" +
                              $"Email: {message.Email}, \n\t" +
                              $"Имя: {message.FirstName} {message.LastName}, \n\t" +
                              $"Создан: {message.CreatedAt:yyyy-MM-dd HH:mm:ss}");
    }
}
