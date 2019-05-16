using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class User : BaseEntity
    {
        #region Properties

        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string City { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public virtual Role Role { get; set; }

        public int RoleId { get; set; }

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