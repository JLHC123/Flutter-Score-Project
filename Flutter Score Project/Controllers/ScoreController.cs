using Flutter_Score_Project.Data;
using Flutter_Score_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flutter_Score_Project.Controllers
{
    public class ScoreController : ControllerBase
    {
        [HttpGet("GetScores")]
        public IActionResult GetScores()
        {
            ScoreContext _context = new ScoreContext();
            var scores = _context.score.ToList();
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
    }
}
