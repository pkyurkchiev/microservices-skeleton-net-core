using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class Discipline : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public ICollection<Test> Tests { get; set; }

        public Discipline()
        {
            this.Tests = new HashSet<Test>();
        }
    }
}
