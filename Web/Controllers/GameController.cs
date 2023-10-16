using ChessApi.DTO;
using ChessApi.GameInterfaces;
using ChessApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace ChessApi.Controllers;

[ApiController]
[Route("Game")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDTO>>> Get()
    {
        var games = await _gameService.GetAllGamesAsync();

        return Ok(games);
    }


    [HttpPost("/createGame")]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameDTO createGameDTO)
    {
        try
        {
            var newGame = new Game
            {
                WhiteUserId = createGameDTO.WhiteUserId,
                BlackUserId = createGameDTO.BlackUserId,
                UpdatedAt = DateTime.Now,
            };

           
            var createdGame = await _gameService.CreateGameAsync(newGame);
            
            return Ok(createdGame);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}