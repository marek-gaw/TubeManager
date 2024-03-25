using TubeManager.API.Repositories;
using TubeManager.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IBookmarkRepository, InMemoryBookmarkRepository>()
    .AddSingleton<IBookmarksService, BookmarksService>()
    .AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
