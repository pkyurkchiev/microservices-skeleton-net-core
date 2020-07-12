using KnowledgeBase.Data.Entities;
using KnowledgeBase.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Data.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(KnowledgeBaseDbContext context) 
            : base(context) { }

        public async Task MarkTestFinish(Guid testId, ExecutionStatusEnum executionStatus)
        {
            Test test = await this.GetById(testId);
            test.Status = TestStatusEnum.Completed;
            test.FinishedOn = DateTime.UtcNow;
            test.ExecutionStatus = executionStatus;
        }

        public async Task<IList<Test>> GetByUserId(Guid externalUserId)
        {
            return await (from test in Context.Tests
                          join userTest in Context.UserTests on test.Id equals userTest.TestId
                          join user in Context.Users on userTest.UserId equals user.Id
                          where user.ExternalId == externalUserId
                          select test).ToListAsync();
        }
    }
}
