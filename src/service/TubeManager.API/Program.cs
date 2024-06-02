using TubeManager.App;
using TubeManager.Infrastructure;
using Serilog;

var specificOrgins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: specificOrgins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .WithHeaders("Content-Type");
        });
});

builder.Services
    .AddInfrastructure()
    .AddApp()
    .AddControllers();

builder.Services.AddOpenApiDocument();

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo
        .Console();
});

var app = builder.Build();
app.UseRouting();
app.UseCors(specificOrgins);
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.Run();