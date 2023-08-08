using Marketplace.Infra.Context;
using Marketplace.Infra.CrossCutting;
using Marketplace.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add dependency injection to service provider.

builder.Services.ConfigureDependencyInjection(builder.Configuration)
                .ConfigureDbContexts(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add background service RabbitMq.
builder.Services.AddHostedService<RabbitMqConsumeHandler>();

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
