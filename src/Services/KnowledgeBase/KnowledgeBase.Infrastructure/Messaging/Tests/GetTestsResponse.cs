using KnowledgeBase.Infrastructure.ViewModels;
using System.Collections.Generic;

namespace KnowledgeBase.Infrastructure.Messaging.Tests
{
    public class GetTestsResponse : ServiceResponseBase
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
    }
}
