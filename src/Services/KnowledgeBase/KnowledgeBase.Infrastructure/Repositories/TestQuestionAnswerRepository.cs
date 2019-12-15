using KnowledgeBase.Data;
using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class TestQuestionAnswerRepository : Repository<TestQuestionAnswer>, ITestQuestionAnswerRepository
    {
        public TestQuestionAnswerRepository(KnowledgeBaseDbContext context) : base(context)
        { }

    }
}
