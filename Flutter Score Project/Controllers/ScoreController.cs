using Flutter_Score_Project.Data;
using Flutter_Score_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flutter_Score_Project.Controllers
{
    public class ScoreController : ControllerBase
    {
        [HttpGet("GetScores")]
        public IActionResult GetScores()
        {
            ScoreContext _context = new ScoreContext();
            var scores = _context.score.Include(s => s.User).ToList();
            return Ok(scores);
        }

        [HttpPost("AddScore")]
        public IActionResult AddScore(Score score)
        {
            ScoreContext _context = new ScoreContext();
            _context.score.Add(score);
            _context.SaveChanges();
            return Ok(score);
        }

        [HttpDelete("DeleteScore")]
        public IActionResult DeleteScore(long ScoreId)
        {
            ScoreContext _context = new ScoreContext();
            var score = _context.score.Find(ScoreId);
            if (score == null)
            {
                return NotFound();
            }
            _context.score.Remove(score);
            _context.SaveChanges();
            return Ok(score);
        }

        [HttpGet("GetScoresSorted")]
        public IActionResult GetScoreSorted()
        {
            ScoreContext _context = new ScoreContext();
            try
            {
                var sortedScores = _context.score.Include(s => s.User).OrderByDescending(s => s.ScoreResult).ToList();
                return Ok(sortedScores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("GetUserSortedScores")]
        public IActionResult GetUserScores(long UserId)
        {
            ScoreContext _context = new ScoreContext();
            var user = _context.user.Find(UserId);
            if (user == null)
            {
                return NotFound($"User with ID {UserId} not found.");
            }
            var userSortedScores = _context.score
                .Where(s => s.UserId == UserId)
                .OrderByDescending(s => s.ScoreResult)
                .ToList();
            return Ok(userSortedScores);

        }
    }
}
