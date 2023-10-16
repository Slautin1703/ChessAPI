using ChessApi.GameInterfaces;
using ChessApi.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = ChessApi.Data.DbContext;

public class GameRepository : IGameRepository
{
    private readonly DbContext _dbContext;

    public GameRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Game>> GetAllGamesAsync()
    {
        return await _dbContext.Games
            .Include(g => g.WhiteUser)
            // .ThenInclude(u => u.AssociatedGames)
            .ToListAsync();
    }


    public async Task<Game> GetGameByIdAsync(int gameId)
    {
        return await _dbContext.Games.FindAsync(gameId);
    }

    public async Task<Game> AddGameAsync(Game game)
    {
        _dbContext.Games.Add(game);
        await _dbContext.SaveChangesAsync();
        return game;
    }

    public async Task UpdateGameAsync(Game game)
    {
        _dbContext.Entry(game).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(Game game)
    {
        _dbContext.Games.Remove(game);
        await _dbContext.SaveChangesAsync();
    }
}
