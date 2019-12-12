using System.Collections.Generic;

namespace KnowledgeBase.Data.Entities
{
    public class Test : BaseEntity
    {
        #region Properties

        public string Description { get; set; }

        public ICollection<UserTest> UserTests { get; set; }
        public ICollection<TestQuestionAnswer> TestQuestionAnswers { get; set; }

        #endregion
    }
}
