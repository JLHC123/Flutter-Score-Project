using Flutter_Score_Project.Data;
using Flutter_Score_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flutter_Score_Project.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost("Register")]
        public IActionResult Register(string UserName, string Password, string Email)
        {
            ScoreContext _context = new ScoreContext();
            if (_context.user.Any(u => u.UserName == UserName))
            {
                return BadRequest(new { message = "Username already exists!" });
            }
            if (_context.user.Any(u => u.Email == Email))
            {
                return BadRequest(new { message = "Email already exists!" });
            }
            var newUser = new User
            {
                UserName = UserName,
                Password = Password,
                Email = Email
            };
            _context.user.Add(newUser);
            _context.SaveChanges();
            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("Login")]
        public IActionResult Login(string UserName, string Password)
        {
            ScoreContext _context = new ScoreContext();
            var user = _context.user.FirstOrDefault(u => u.UserName == UserName && u.Password == Password);
            if (user == null)
            {
                return BadRequest(new { message = "Invalid username or password!" });
            }
            return Ok(new { message = "Login successful!", userId = user.UserId });
        }
    }
}
