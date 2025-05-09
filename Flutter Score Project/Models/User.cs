using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Flutter_Score_Project.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [JsonIgnore] // prevents endless loop cycle between User and Score callbacks
        public ICollection<Score> Scores { get; set; }
    }
}
