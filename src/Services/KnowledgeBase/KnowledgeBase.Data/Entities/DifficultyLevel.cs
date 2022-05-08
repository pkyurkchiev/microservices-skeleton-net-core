using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class DifficultyLevel : BaseEntity
    {
        [StringLength(150)]
        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; }

        public DifficultyLevel()
        {
            this.Questions = new HashSet<Question>();
        }
    }
}
