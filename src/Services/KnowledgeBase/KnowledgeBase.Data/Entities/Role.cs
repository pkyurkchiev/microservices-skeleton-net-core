using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class Role : BaseEntity
    {
        #region Properties

        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        #endregion

        #region Costructor

        public Role()
        {
            this.Users = new HashSet<User>();
        }

        #endregion
    }
}
