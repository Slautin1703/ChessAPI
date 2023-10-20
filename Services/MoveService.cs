using ChessApi.Models;
using ChessApi.MoveInterfaces;

namespace ChessApi.Services;

public class MoveService: IMoveService
{
    private readonly IMoveRepository _moveRepository;

    public MoveService(IMoveRepository moveRepository)
    {
        _moveRepository = moveRepository;
    }
    
    public async Task<Move> AddMoveAsync(Move game)
    {
        return await _moveRepository.AddMoveAsync(game);
    }
    
    public async Task<IEnumerable<Move>> GetAllMovesByGameIdAsync(int gameId)
    {
        var moves = await _moveRepository.GetAllMovesByGameIdAsync(gameId);
        
        return moves;
    }
}