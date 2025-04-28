using System.ComponentModel.DataAnnotations.Schema;

namespace Flutter_Score_Project.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Score> Scores { get; set; }
    }
}
