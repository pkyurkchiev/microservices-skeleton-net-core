namespace KnowledgeBase.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Answer : BaseEntity
    {
        #region Properties

        [StringLength(500)]
        public string Text { get; set; }

        //public ICollection<Question> Questions { get; set; }

        #endregion

        #region Constuctors

        //public Answer()
        //{
        //    this.Questions = new HashSet<Question>();
        //}

        #endregion

    }
}
