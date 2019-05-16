namespace KnowledgeBase.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using Interfaces;

    public abstract class BaseEntity : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
