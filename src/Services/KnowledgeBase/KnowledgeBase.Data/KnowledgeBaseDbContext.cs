using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Data
{
    public class KnowledgeBaseDbContext : DbContext
    {
        public KnowledgeBaseDbContext(DbContextOptions<KnowledgeBaseDbContext> options)
            : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Question>()
            //           .HasIndex(q => q.CorrectAnswer)
            //           .IsUnique();
        }
    }
}
