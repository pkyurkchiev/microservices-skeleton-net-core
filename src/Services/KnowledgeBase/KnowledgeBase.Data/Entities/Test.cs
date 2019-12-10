using System.Collections.Generic;

namespace KnowledgeBase.Data.Entities
{
    public class Test : BaseEntity
    {
        #region Properties

        public string Comments { get; set; }

        public ICollection<UserTest> UserTests { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; set; }

        #endregion
    }
}
