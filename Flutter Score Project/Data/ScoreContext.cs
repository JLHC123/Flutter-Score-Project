using Flutter_Score_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Flutter_Score_Project.Data
{
    public class ScoreContext : DbContext
    {
        public String ConnectionString = "Data Source=LAPTOP-E849FIKF;Initial Catalog=\"Flutter Score\";Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Score> score { get; set; }
        public DbSet<User> user { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Scores)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
