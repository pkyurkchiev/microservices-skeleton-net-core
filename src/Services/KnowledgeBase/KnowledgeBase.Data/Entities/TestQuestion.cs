using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBase.Data.Entities
{
    public class TestQuestion
    {
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
