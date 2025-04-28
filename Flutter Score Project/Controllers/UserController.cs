using Flutter_Score_Project.Data;
using Flutter_Score_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flutter_Score_Project.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            ScoreContext _context = new ScoreContext();
            var users = _context.user.ToList();
            return Ok(users);
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            ScoreContext _context = new ScoreContext();
            _context.user.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(long UserId)
        {
            ScoreContext _context = new ScoreContext();
            var user = _context.user.Find(UserId);
            if (user == null)
            {
                return NotFound();
            }
            _context.user.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }
    }
}
