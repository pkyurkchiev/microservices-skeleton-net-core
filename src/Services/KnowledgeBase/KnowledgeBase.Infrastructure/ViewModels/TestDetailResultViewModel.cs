using System;
using System.Collections.Generic;

namespace KnowledgeBase.Infrastructure.ViewModels
{
    public sealed class TestDetailResultViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<QuestionResultViewModel> QuestionResultViewModels { get; set; }

        public TestDetailResultViewModel()
        {
            QuestionResultViewModels = new List<QuestionResultViewModel>();
        }
    }

    public sealed class QuestionResultViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public DateTime? MarkOn { get; set; }
        public List<AnswerResultViewModel> AnswerResultViewModels { get; set; }

        public QuestionResultViewModel()
        {
            AnswerResultViewModels = new List<AnswerResultViewModel>();
        }
    }

    public sealed class AnswerResultViewModel
    {
        public Guid AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool CorrectAnswer { get; set; }
        public bool MarkAnswer { get; set; }
    }
}
