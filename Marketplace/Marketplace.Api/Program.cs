using Marketplace.Infra.Context;
using Marketplace.Infra.CrossCutting;
using Marketplace.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add dependency injection.

builder.Services.ConfigureDependencyInjection(builder.Configuration)
                .ConfigureDbContexts();

builder.Services.AddHostedService<RabbitMqConsumeHandler>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
