namespace KnowledgeBase.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department : BaseEntity
    {
        #region Properties

        [StringLength(150)]
        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        #endregion

        #region Constructors

        public Department()
        {
            this.Questions = new HashSet<Question>();
            this.Tasks = new HashSet<Task>();
        }

        #endregion
    }
}
