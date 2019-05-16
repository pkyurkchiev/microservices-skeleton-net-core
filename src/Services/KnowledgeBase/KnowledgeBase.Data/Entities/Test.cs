using System.Collections.Generic;

namespace KnowledgeBase.Data.Entities
{
    public class Test : BaseEntity
    {
        #region Properties

        public string Comments { get; set; }

        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Question> Questions { get; set; }
        //public virtual ICollection<Task> Tasks { get; set; }

        #endregion

        #region Constructors

        //public Test()
        //{
        //    this.Users = new HashSet<User>();
        //    this.Questions = new HashSet<Question>();
        //    this.Tasks = new HashSet<Task>();
        //}

        #endregion
    }
}
