using Application.Events.Users.CreateUser;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Consumers.Users.CreateUserConsumer;

public class CreateUserConsumer(ILogger<CreateUserConsumer> logger) : IConsumer<CreateUserEvent>
{
    public async Task Consume(ConsumeContext<CreateUserEvent> context)
    {
        var message = context.Message;

        logger.LogInformation("[CONSUMER] ✅ Получено событие создания пользователя: " +
                              $"ID: {message.Id}, " +
                              $"Email: {message.Email}, " +
                              $"Имя: {message.FirstName} {message.LastName}, " +
                              $"Создан: {message.CreatedAt:yyyy-MM-dd HH:mm:ss}");

        logger.LogInformation("[CONSUMER] ✅ Обработка пользователя завершена: " + message.Email);
    }
}
