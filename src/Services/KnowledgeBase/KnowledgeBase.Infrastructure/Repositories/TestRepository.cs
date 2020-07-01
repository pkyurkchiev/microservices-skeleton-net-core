using KnowledgeBase.Data;
using KnowledgeBase.Data.Entities;
using System;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(KnowledgeBaseDbContext context) 
            : base(context) { }

        public async Task MarkTestFinish(Guid testId)
        {
            Test test = await this.GetById(testId);
            test.IsFinish = true;
            test.FinishedOn = DateTime.UtcNow;
        }
    }
}
