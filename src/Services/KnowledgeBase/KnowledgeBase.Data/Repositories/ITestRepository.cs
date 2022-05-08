using KnowledgeBase.Data.Entities;
using KnowledgeBase.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeBase.Data.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task MarkTestFinish(Guid testId, ExecutionStatusEnum executionStatus);
        Task<IList<Test>> GetByUserId(Guid externalUserId);
    }
}
