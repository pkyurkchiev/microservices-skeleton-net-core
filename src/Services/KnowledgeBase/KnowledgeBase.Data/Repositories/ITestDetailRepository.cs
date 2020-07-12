using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeBase.Data.Repositories
{
    public interface ITestDetailRepository : IRepository<TestDetail>
    {
        Task<IList<TestDetail>> GetByTestId(Guid testId);
        Task<IList<TestDetail>> GetByUserExternalId(string userExternalId);
        Task<IList<TestDetail>> GetTestResults(Guid testId);
        Task MarkAnswer(Guid testId, Guid questionId, Guid answerId, Guid userId);
        Task GenerateTests(Guid disciplineId, string description, Guid userId);
    }
}
