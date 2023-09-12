using Marketplace.Infra.Context;
using Marketplace.Infra.CrossCutting;
using FluentValidation.AspNetCore;
using Marketplace.Api.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Api.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Add dependency injection to service provider.
builder.Services.ConfigureDependencyInjection(builder.Configuration)
                .ConfigureDbContexts(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add api versioning
builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1, 0);
});

builder.Services.AddVersionedApiExplorer(config =>
{
    config.GroupNameFormat = "'v'VVV";
    config.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(gen =>
{
    gen.OperationFilter<SwaggerDefaultValues>();
});

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

//Add background service RabbitMq.
//builder.Services.AddHostedService<RabbitMqConsumerHandler>(). //Commented to run without rabbitMqConsummer.

//Add fluent validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<NewUserInputValidator>();

var app = builder.Build();

var versionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var groupName in versionDescriptionProvider.ApiVersionDescriptions.Select(description => description.GroupName))
    {
        options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json",
            $"Marketplace.Api - {groupName.ToUpper()}");
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
