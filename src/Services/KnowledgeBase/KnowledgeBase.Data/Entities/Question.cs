using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeBase.Data.Entities
{
    public class Question : BaseEntity
    {
        [StringLength(500)]
        public string Text { get; set; }

        public Guid CorrectAnswerId { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Guid DifficultyLevelId { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }

        public Guid DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<TestDetail> TestDetails { get; set; }

        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }
    }
}
