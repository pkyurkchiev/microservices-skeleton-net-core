using System;
using System.Collections.Generic;

namespace KnowledgeBase.Infrastructure.ViewModels
{
    public sealed class TestDetailViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<QuestionViewModel> QuestionViewModels { get; set; }

        public TestDetailViewModel()
        {
            QuestionViewModels = new List<QuestionViewModel>();
        }
    }

    public sealed class QuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerViewModel> AnswerViewModels { get; set; }

        public QuestionViewModel()
        {
            AnswerViewModels = new List<AnswerViewModel>();
        }
    }

    public sealed class AnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public string AnswerText { get; set; }
        public bool MarkAnswer { get; set; }
    }
}
