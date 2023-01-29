using System.Reflection;
using MassTransit;
using UserService.Api.Domain;
using UserService.Api.Infrastructure;
using UserService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//--------------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//--------------
builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<IUserService, UserService.Api.Services.UserService>();
//--------------

builder.Services.AddMassTransit(x =>
{
    var entryAssembly = Assembly.GetEntryAssembly();
    x.AddConsumers(entryAssembly);
    x.UsingRabbitMq(configure: (delegate (IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        configurator.ConfigureEndpoints(context);
    }));
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
