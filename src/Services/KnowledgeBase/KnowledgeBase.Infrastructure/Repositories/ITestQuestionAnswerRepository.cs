using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public interface ITestQuestionAnswerRepository : IRepository<TestQuestionAnswer>
    {
        Task<IList<TestQuestionAnswer>> GetByUserId(Guid userId);
        Task GenerateTests();
    }
}
