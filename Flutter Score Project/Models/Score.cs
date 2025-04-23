using System.ComponentModel.DataAnnotations.Schema;

namespace Flutter_Score_Project.Models
{
    public class Score
    {
        public long ScoreId { get; set; }
        public int ScoreResult { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }
    }
}
