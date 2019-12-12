using KnowledgeBase.Data;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        KnowledgeBaseDbContext Context { get; }
        TRepository GetRepository<TRepository>() where TRepository : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
