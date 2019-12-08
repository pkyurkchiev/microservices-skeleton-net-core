using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(DbContext context) : base(context)
        {
        }
    }
}
