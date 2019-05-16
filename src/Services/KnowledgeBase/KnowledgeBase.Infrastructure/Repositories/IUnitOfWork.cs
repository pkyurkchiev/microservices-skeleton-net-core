using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KnowledgeBase.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IRepository<Role> Roles { get; }

        IRepository<Test> Tests { get; }

        IRepository<Question> Questions { get; }

        IRepository<User> Users { get; }

        IRepository<DifficultyLevel> Levels { get; }

        IRepository<Department> Departments { get; }

        IRepository<Task> Tasks { get; }

        IRepository<Answer> Answers { get; }

        int Commit();
    }
}
