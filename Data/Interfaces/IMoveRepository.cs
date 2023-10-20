using ChessApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChessApi.MoveInterfaces
{
    public interface IMoveRepository
    {
        Task<IEnumerable<Move>> GetAllMovesByGameIdAsync(int gameId);
        // Task<Move> GetMoveByIdAsync(int moveId);
        Task<Move> AddMoveAsync(Move game);
    }
}