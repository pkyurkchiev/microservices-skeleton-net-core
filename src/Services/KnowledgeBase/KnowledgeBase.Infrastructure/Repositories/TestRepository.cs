using KnowledgeBase.Data;
using KnowledgeBase.Data.Entities;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(KnowledgeBaseDbContext context) 
            : base(context) { }

    }
}
