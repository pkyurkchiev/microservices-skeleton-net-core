using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KnowledgeBase.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        
        IRepository<Test> Tests { get; }

        IRepository<Question> Questions { get; }

        IRepository<User> Users { get; }

        IRepository<DifficultyLevel> DifficultyLevels { get; }

        IRepository<Answer> Answers { get; }

        int Commit();
    }
}
