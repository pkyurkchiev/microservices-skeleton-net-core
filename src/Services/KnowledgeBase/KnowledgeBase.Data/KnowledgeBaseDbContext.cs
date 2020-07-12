using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Data
{
    public class KnowledgeBaseDbContext : DbContext
    {
        public KnowledgeBaseDbContext(DbContextOptions<KnowledgeBaseDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<UserTest> UserTests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestDetail>()
                .HasKey(bc => new { bc.TestId, bc.QuestionId, bc.AnswerId });
            modelBuilder.Entity<TestDetail>()
                .HasOne(bc => bc.Test)
                .WithMany(b => b.TestDetails)
                .HasForeignKey(bc => bc.TestId);
            modelBuilder.Entity<TestDetail>()
                .HasOne(bc => bc.Question)
                .WithMany(c => c.TestDetails)
                .HasForeignKey(bc => bc.QuestionId)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<TestDetail>()
                .HasOne(bc => bc.Answer)
                .WithMany(c => c.TestDetails)
                .HasForeignKey(bc => bc.AnswerId)
                .Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<UserTest>()
                .HasKey(bc => new { bc.UserId, bc.TestId });
            modelBuilder.Entity<UserTest>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserTests)
                .HasForeignKey(bc => bc.UserId);
            modelBuilder.Entity<UserTest>()
                .HasOne(bc => bc.Test)
                .WithMany(c => c.UserTests)
                .HasForeignKey(bc => bc.TestId);
        }
    }
}
