using System.Security.Claims;
using ChessApi.DTO;
using ChessApi.Models;
using ChessApi.MoveInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChessApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MoveController: ControllerBase
{
    
    private readonly IMoveService _moveService;

    public MoveController(IMoveService moveService)
    {
        _moveService = moveService;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Move>> Post(CreateMoveDTO move)
    {
        try
        {
            var newMove = new Move
            {
                GameId = move.GameId,
                PlayerId = move.PlayerId
            };
            
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            
            
           
            // var createdMove = await _moveService.AddMoveAsync(newMove);
            
            return Ok(userIdClaim);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}