using KnowledgeBase.Data.Entities;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.Data.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task MarkTestFinish(Guid testId);
    }
}
