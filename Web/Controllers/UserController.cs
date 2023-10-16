using ChessApi.Data;
using ChessApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DbContext = ChessApi.Data.DbContext;

namespace ChessApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DbContext Context;

    public UserController(DbContext context)
    {
        Context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        List<User> users = await Context.Users
            .Include(x => x.BlackGames)
            .Include(x => x.WhiteGames)
            .ToListAsync();
        
        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult> Post(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();

        return Ok();
    }
}