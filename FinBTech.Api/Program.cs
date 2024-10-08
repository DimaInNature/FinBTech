var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.AddHttpContextAccessor();

services.AddFeatureManagement()
    .AddFeatureFilter<RequestResponseLoggingFilter>();

services.AddRequestResponseLogging();

services.AddMappingConfiguration();

services.AddApplicationContext()
    .AddRepositories();

services.AddServices();

services.AddApiVersioningConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseRequestResponseLogging();

app.Run();