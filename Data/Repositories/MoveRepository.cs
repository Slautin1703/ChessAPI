using ChessApi.Models;
using ChessApi.MoveInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChessApi.Data.Repositories;

public class MoveRepository: IMoveRepository
{
    private readonly DbContext _dbContext;

    public MoveRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [Authorize]
    public async Task<IEnumerable<Move>> GetAllMovesByGameIdAsync(int gameId)
    {
        return await _dbContext.Moves.Where(move => move.GameId == gameId).ToListAsync();
    }

    public async Task<Move> AddMoveAsync(Move move)
    {
        _dbContext.Moves.Add(move);
        await _dbContext.SaveChangesAsync();

        return move;
    }
}