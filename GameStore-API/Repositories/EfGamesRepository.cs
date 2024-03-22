using GameStore_API.Data;
using GameStore_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore_API.Repositories;

public class EfGamesRepository : IGamesRepository
{
    private readonly GameStoreContext _dbContext;

    public EfGamesRepository(GameStoreContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _dbContext.Games.AsNoTracking().ToListAsync();
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await _dbContext.Games.FindAsync(id);
    }

    public async Task CreateAsync(Game game)
    {
        game.ReleaseDate = game.ReleaseDate.ToUniversalTime();
        
        _dbContext.Games.Add(game);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        _dbContext.Update(updatedGame);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int id)
    {
        await _dbContext.Games
            .Where(game => game.Id == id)
            .ExecuteDeleteAsync();
    }
}