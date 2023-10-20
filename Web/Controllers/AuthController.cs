using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ChessApi.Data;
using ChessApi.DTO;
using ChessApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using DbContext = ChessApi.Data.DbContext;

namespace ChessApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
        private readonly IConfiguration _config;
        private readonly DbContext Context;

        public AuthController(IConfiguration config, DbContext context)
        {
            _config = config;
            Context = context;
        }

        private string CreateToken()
        {
            IConfigurationSection section = _config.GetSection("JWT");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section.GetValue<string>("Token")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var issuer = section.GetValue<string>("Issuer");
            var audience = section.GetValue<string>("Audience");
            var expirationHours = section.GetValue<int>("ExpirationHours");
        
            var token = new JwtSecurityToken(issuer,
                audience, 
                expires: DateTime.Now.AddHours(expirationHours),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("/Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO user)
        {

            UserDTO? foundUser = await Context.Users
            .Where(value => value.UserName == user.UserName)
            .Select(value => new UserDTO() {
                UserName = value.UserName,
                Password = value.Password,
                Name = value.Name,
                RatingAmount = value.RatingAmount,
            })
            .FirstOrDefaultAsync();

            if (foundUser == null) {
                return NotFound(new {message = "Not found"});
            }

            bool valid = BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password);

            if (valid) {
                return Ok(new {token = CreateToken()});
            } 
            
            return BadRequest(new {message = "It was a bad password mate, try again"});
        }
    }
}