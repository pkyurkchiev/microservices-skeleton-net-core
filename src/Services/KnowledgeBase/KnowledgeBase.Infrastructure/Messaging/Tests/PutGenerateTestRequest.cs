using System;

namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class PutGenerateTestRequest : ServiceRequestBase
    {
        public Guid DisciplineId { get; set; }
        public BodyModel Body { get; set; }

        public PutGenerateTestRequest(Guid disciplineId, BodyModel body)
        {
            DisciplineId = disciplineId;
            Body = body;
        }
    }

    public class BodyModel
    {
        public string Description { get; set; }
    }
}
