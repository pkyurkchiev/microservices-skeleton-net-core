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

        public ICollection<UserTest> UserTests { get; set; }

        #endregion
    }
}