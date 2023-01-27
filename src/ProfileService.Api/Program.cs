using MassTransit;
using MassTransit.RabbitMqTransport;
using Messaging.Common;
using ProfileService.Api.Domain;
using ProfileService.Api.Infrastructure;
using ProfileService.Api.Messaging;
using ProfileService.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//--------------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//--------------
builder.Services.AddSingleton<IProfileRepository, InMemoryProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService.Api.Services.ProfileService>();
//--------------
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq(configure:(delegate(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.Host("rabbitmq","/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        configurator.ConfigureEndpoints(context);
    }));
});
//--------------
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
