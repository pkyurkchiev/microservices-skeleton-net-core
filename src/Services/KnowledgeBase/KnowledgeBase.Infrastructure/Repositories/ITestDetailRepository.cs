using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public interface ITestDetailRepository : IRepository<TestDetail>
    {
        Task<IList<TestDetail>> GetByUserId(Guid userId);
        Task<IList<TestDetail>> GetByUserExternalId(string userExternalId);
        Task MarkAnswer(Guid testId, Guid questionId, Guid answerId);
        Task GenerateTests();
    }
}
