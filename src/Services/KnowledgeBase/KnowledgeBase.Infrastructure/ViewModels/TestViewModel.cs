using KnowledgeBase.Data.Entities.Enums;
using System;

namespace KnowledgeBase.Infrastructure.ViewModels
{
    public class TestViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime? FinishedOn { get; set; }
        public TestStatusEnum Status { get; set; }
    }
}
