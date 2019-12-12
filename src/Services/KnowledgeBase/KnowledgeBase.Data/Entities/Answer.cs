namespace KnowledgeBase.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Answer : BaseEntity
    {
        #region Properties

        [StringLength(500)]
        public string Text { get; set; }

        #endregion
    }
}
