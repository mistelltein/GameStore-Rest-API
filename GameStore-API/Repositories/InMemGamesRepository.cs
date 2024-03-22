using GameStore_API.Entities;

namespace GameStore_API.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
    {
        new Game()
        {
            Id = 1,
            Name = "Minecraft",
            Genre = "Sandbox",
            Price = 9.99M,
            ReleaseDate = new DateTime(2011, 11, 18),
            ImageUri = "https://placehold.co/100"
        },
        new Game()
        {
            Id = 2,
            Name = "Terraria",
            Genre = "Adventure sandbox",
            Price = 9.99M,
            ReleaseDate = new DateTime(2011, 05, 16),
            ImageUri = "https://placehold.co/100"
        },
        new Game()
        {
            Id = 3,
            Name = "Hollow Knight",
            Genre = "Action-Adventure",
            Price = 14.99M,
            ReleaseDate = new DateTime(2017, 02, 24),
            ImageUri = "https://placehold.co/100"
        },
    };

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(games);
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await Task.FromResult(games.Find(game => game.Id == id));
    }

    public async Task CreateAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);

        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);

        await Task.CompletedTask;
    }
}