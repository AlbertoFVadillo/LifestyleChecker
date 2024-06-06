using LifestyleChecker.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace LifestyleChecker.DataLayer
{
    public class ScoreContext : DbContext
    {
        public ScoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>().HasData(new Score
            {
                Score_ID = 1,
                From = 16,
                To = 21,
                Q1 = 1,
                Q2 = 2,
                Q3 = 1
            },
            new Score
            {
                Score_ID = 2,
                From = 22,
                To = 40,
                Q1 = 2,
                Q2 = 2,
                Q3 = 3
            },
            new Score
            {
                Score_ID = 3,
                From = 41,
                To = 65,
                Q1 = 3,
                Q2 = 2,
                Q3 = 2
            },
            new Score
            {
                Score_ID = 4,
                From = 64,
                Q1 = 3,
                Q2 = 3,
                Q3 = 1
            }
            );
        }
    }
}
