using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string FacultyNumber { get; set; }
        public Guid ExternalId { get; set; }

        public ICollection<UserTest> UserTests { get; set; }
    }
}