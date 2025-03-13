using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Apimedical.Controllers
{
    [Route("auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Email == "admin@example.com" && request.Password == "123456") // 🔑 Cambia estos valores
            {
                var token = GenerateJwtToken(request.Email);
                return Ok(new { Token = token });
            }
            return Unauthorized("Credenciales inválidas.");
        }

        private string GenerateJwtToken(string email)
        {
            var key = Encoding.ASCII.GetBytes("zRMv4Xvdl1zr/N2qP6C5KlZziE9VX45P+sbNvI/oBzM="); // 🔑 Usa la misma clave de `Program.cs`
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
                Expires = DateTime.UtcNow.AddHours(100), // ⏳ Token válido por 100 horas
                Issuer = "imedical.com",  // 🔥 Agregar esto
                Audience = "imedical.com",  // 🔥 Agregar esto
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
