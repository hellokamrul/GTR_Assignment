using GTR_Assign.Context;
using GTR_Assign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace GTR_Assign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly EshopDbContext _context;

        public JwtController(IConfiguration configuration, EshopDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            if(user != null && user.Email != null && user.Password != null)
            {
                var userData = await GetUser(user.Email, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()), 
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Email",user.Email),
                        new Claim("Password",user.Password)
                       // new Claim("Gender",user.Gender),
                       // new Claim("Address",user.Address),
                       // new Claim("Name",user.Name),
                       // new Claim("Phone",user.Phone)

                        
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20)
                        
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credential..!");
                }

            }
            else
            {
                return BadRequest("Invalid Credential..!");
            }
        }
        [HttpGet]
        public async Task<User> GetUser(string email, string pass)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == pass);
        }
    }
}
