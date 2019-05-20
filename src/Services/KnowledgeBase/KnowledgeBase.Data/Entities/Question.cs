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

        //[Index(IsUnique = true)]
        public Guid CorrectAnswerId { get; set; }

        public Guid DifficultyLevelId { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }

        public virtual Answer CorrectAnswer { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Test> Tests { get; set; }

        #endregion

        #region Constructors

        public Question()
        {
            this.Answers = new HashSet<Answer>();
            this.Tests = new HashSet<Test>();
        }

        #endregion
    }
}
