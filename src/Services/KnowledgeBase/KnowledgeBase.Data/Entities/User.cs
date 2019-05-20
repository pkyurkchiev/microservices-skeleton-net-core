using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class User : BaseEntity
    {
        #region Properties

        [Required]
        [StringLength(15)]
        public string ExternalId { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
        #endregion

        #region Constructors

        public User()
        {
            this.Tests = new HashSet<Test>();
        }

        #endregion
    }
}