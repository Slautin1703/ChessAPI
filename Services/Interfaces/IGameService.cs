using ChessApi.Models;


namespace ChessApi.GameInterfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game> CreateGameAsync(Game game);
        Task<Game> UpdateGameAsync(int gameId, Game updatedGame);
        Task<bool> DeleteGameAsync(int gameId);
    }
}
