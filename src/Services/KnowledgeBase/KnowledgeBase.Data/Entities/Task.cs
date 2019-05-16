using System.Collections.Generic;

namespace KnowledgeBase.Data.Entities
{
    public class Task : BaseEntity
    {
        #region Properties

        public string Title { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public int LevelId { get; set; }

        public virtual Department Department { get; set; }
        public virtual DifficultyLevel Level { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

        #endregion

        #region Constructors

        public Task()
        {
            this.Tests = new HashSet<Test>();
        }

        #endregion
    }
}
