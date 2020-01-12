namespace KnowledgeBase.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Question : BaseEntity
    {
        #region Properties

        [StringLength(500)]
        public string Text { get; set; }

        public Guid CorrectAnswerId { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Guid DifficultyLevelId { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<TestDetail> TestDetails { get; set; }
        #endregion

        #region Constructors
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }
        #endregion
    }
}
