using KnowledgeBase.Data.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public abstract class BaseEntity : ISoftDelete
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
