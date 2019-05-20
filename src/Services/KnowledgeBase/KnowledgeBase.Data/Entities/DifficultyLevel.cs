using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class DifficultyLevel : BaseEntity
    {
        #region Properties

        [StringLength(150)]
        public string Title { get; set; }


        public virtual ICollection<Question> Questions { get; set; }

        #endregion

        #region Constuctors

        public DifficultyLevel()
        {
            this.Questions = new HashSet<Question>();
        }

        #endregion
    }
}
