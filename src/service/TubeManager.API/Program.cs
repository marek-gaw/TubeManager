using TubeManager.App;
using TubeManager.Infrastructure;

var specificOrgins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: specificOrgins,
        policy  =>
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

var app = builder.Build();
app.UseRouting();
app.UseCors(specificOrgins);
app.MapControllers();

app.Run();
