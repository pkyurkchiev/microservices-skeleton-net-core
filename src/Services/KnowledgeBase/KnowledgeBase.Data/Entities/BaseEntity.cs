namespace KnowledgeBase.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using Interfaces;
    using System;

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
