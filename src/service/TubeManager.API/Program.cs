using TubeManager.App;
using TubeManager.Infrastructure;

var  specificOrgins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: specificOrgins,
        policy  =>
        {
            policy.WithOrigins(
                "http://localhost:4200",
                "http://localhost:5126"
                );
        });
});

builder.Services
    .AddApp()
    .AddInfrastructure()
    .AddControllers();

var app = builder.Build();

app.UseCors(specificOrgins);
app.MapControllers();

app.Run();
