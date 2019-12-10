using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
            modelBuilder.Entity<TestQuestion>()
                .HasKey(bc => new { bc.TestId, bc.QuestionId });
            modelBuilder.Entity<TestQuestion>()
                .HasOne(bc => bc.Test)
                .WithMany(b => b.TestQuestions)
                .HasForeignKey(bc => bc.TestId);
            modelBuilder.Entity<TestQuestion>()
                .HasOne(bc => bc.Question)
                .WithMany(c => c.TestQuestions)
                .HasForeignKey(bc => bc.QuestionId);

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

        //public class KnowledgeBaseContextDesignFactory : IDesignTimeDbContextFactory<KnowledgeBaseDbContext>
        //{
        //    public KnowledgeBaseDbContext CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<KnowledgeBaseDbContext>()
        //            .UseSqlServer("Server=tcp:127.0.0.1,5433;Database=SkeletonOnContainers.Services.KnowledgeBaseDb;User Id=sa;Password=Pass@word;");

        //        return new KnowledgeBaseDbContext(optionsBuilder.Options);
        //    }
        //}
    }
}
