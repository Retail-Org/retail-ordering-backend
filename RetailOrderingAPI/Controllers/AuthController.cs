using Microsoft.AspNetCore.Mvc;
using RetailOrderingAPI.Data;
using RetailOrderingAPI.DTOs;
using RetailOrderingAPI;
using RetailOrderingAPI.Services;

namespace RetailOrderingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwt;

        public AuthController(AppDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
                return Unauthorized("Invalid email");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isValid)
                return Unauthorized("Invalid password");

            var token = _jwt.GenerateToken(user);

            return Ok(new { token });
        }
    }
}