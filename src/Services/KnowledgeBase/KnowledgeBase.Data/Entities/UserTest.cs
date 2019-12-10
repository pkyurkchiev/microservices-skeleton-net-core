using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBase.Data.Entities
{
    public class UserTest
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
    }
}
