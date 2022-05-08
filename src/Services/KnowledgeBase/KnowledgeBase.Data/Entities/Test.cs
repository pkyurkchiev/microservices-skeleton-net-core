using KnowledgeBase.Data.Entities.Enums;
using System;
using System.Collections.Generic;

namespace KnowledgeBase.Data.Entities
{
    public class Test : BaseEntity
    {
        public Guid? DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public string Description { get; set; }
        public TestStatusEnum Status { get; set; }
        public DateTime? FinishedOn { get; set; }
        public ExecutionStatusEnum? ExecutionStatus { get; set; }

        public ICollection<UserTest> UserTests { get; set; }
        public ICollection<TestDetail> TestDetails { get; set; }
    }
}
