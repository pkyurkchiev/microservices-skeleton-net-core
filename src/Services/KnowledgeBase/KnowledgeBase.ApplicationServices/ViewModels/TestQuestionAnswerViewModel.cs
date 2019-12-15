using System;
using System.Collections.Generic;

namespace KnowledgeBase.ApplicationServices.ViewModels
{
    public sealed class TestQuestionAnswerViewModel
    {
        public Guid Id { get; set; }
        public string Discription { get; set; }
        public List<QuestionViewModel> QuesitonViewModels { get; set; }
    }

    public sealed class QuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerViewModel> AnswerViewModels { get; set; }
    }

    public sealed class AnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public string AnswerText { get; set; }
    }
}
