using ChessApi.Models;

namespace ChessApi.MoveInterfaces;

public interface IMoveService
{
    Task<IEnumerable<Move>> GetAllMovesByGameIdAsync(int gameId);
    Task<Move> AddMoveAsync(Move game);
}