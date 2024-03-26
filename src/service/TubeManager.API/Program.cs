using TubeManager.App;
using TubeManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApp()
    .AddInfrastructure()
    .AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
