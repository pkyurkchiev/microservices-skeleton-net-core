using System;

namespace KnowledgeBase.Data.Entities
{
    public class TestQuestionAnswer : BaseEntity
    {
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public string QuestionText { get; set; }
        public Guid AnswerId { get; set; }
        public Answer Answer { get; set; }
        public string AnswerText { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
