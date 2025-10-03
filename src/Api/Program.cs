using Application.DependencyInjection;
using Application.Interfaces.Services;
using Infrastructure.Consumers.Users.CreateUserConsumer;
using Infrastructure.DbContexts;
using Infrastructure.DependencyInjection;
using Infrastructure.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add layers
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

// Database
builder.Services.AddDbContext<PostgreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MassTransit + RabbitMQ
//builder.Services.AddMassTransit(x =>
//{
//    x.UsingRabbitMq((context, cfg) =>
//    {
//        cfg.Host("localhost", "/", h =>
//        {
//            h.Username("guest");
//            h.Password("guest");
//        });
//    });
//});

// MassTransit + RabbitMQ
builder.Services.AddMassTransit(x =>
{
    // Регистрируем Consumer
    x.AddConsumer<CreateUserConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        // Настраиваем конкретную очередь для Consumer
        cfg.ReceiveEndpoint("user-created-queue", e =>
        {
            e.ConfigureConsumer<CreateUserConsumer>(context);
        });
    });
});

// Message Bus
builder.Services.AddScoped<IMessageBusService, MessageBusService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
