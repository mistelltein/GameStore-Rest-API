using GameStore_API.Data;
using GameStore_API.Endpoints;
using GameStore_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IGamesRepository, EfGamesRepository>();

builder.Services.AddDbContext<GameStoreContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("GameStoreContext")));

var app = builder.Build();

await app.Services.InitializeDbAsync();

app.MapGamesEndpoints();

app.Run();