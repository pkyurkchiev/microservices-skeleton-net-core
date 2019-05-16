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
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<DifficultyLevel> Levels { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
        }
    }

    //public class KnowledgeBaseContextDesignFactory : IDesignTimeDbContextFactory<KnowledgeBaseDbContext>
    //{
    //    public KnowledgeBaseDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<KnowledgeBaseDbContext>()
    //            .UseSqlServer("Server=.;Initial Catalog=SkeletonOnContainers.Services.KnowledgeBaseDb;Integrated Security=true");

    //        return new KnowledgeBaseDbContext(optionsBuilder.Options);
    //    }
    //}
}
