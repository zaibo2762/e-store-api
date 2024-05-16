using e_store.Dbcontext;
using e_store.DTOs;
using e_store.Hasher;
using e_store.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace e_store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbcontext _context;
        private readonly PasswordHasher _passwordHasher;

        public UserController(AppDbcontext context, PasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = new Users
            {
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                Email = userForRegistration.Email,
                PasswordHash = _passwordHasher.HashPassword(userForRegistration.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User created successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLogin)
        {
            var user = await _context.Users.FindAsync(userForLogin.Email);
            if (user != null && _passwordHasher.VerifyPassword(user.PasswordHash, userForLogin.Password))
            {
                return Ok("User logged in successfully");
            }

            return Unauthorized("Invalid email or password");
        }

    }
}
