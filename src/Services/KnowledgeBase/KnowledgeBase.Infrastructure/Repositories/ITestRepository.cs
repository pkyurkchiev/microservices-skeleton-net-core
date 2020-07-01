using KnowledgeBase.Data.Entities;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task MarkTestFinish(Guid testId);
    }
}
