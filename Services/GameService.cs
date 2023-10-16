using ChessApi.GameInterfaces;
using ChessApi.Models;

namespace ChessApi.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _gameRepository.GetAllGamesAsync();
        }


        public async Task<Game> CreateGameAsync(Game game)
        {
            return await _gameRepository.AddGameAsync(game);
        }

        public async Task<Game> UpdateGameAsync(int gameId, Game updatedGame)
        {
            var existingGame = await _gameRepository.GetGameByIdAsync(gameId);

            if (existingGame == null)
            {
                throw new Exception("Game was not found");
            }
            // TODO:  here i need to put some updates 

            await _gameRepository.UpdateGameAsync(existingGame);
            return existingGame;
        }

        public async Task<bool> DeleteGameAsync(int gameId)
        {
            var existingGame = await _gameRepository.GetGameByIdAsync(gameId);

            if (existingGame == null)
            {
                throw new Exception("Game not found");
            }

            await _gameRepository.DeleteGameAsync(existingGame);
            return true;
        }
    }

}

