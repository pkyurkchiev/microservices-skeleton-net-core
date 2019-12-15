using KnowledgeBase.ApplicationServices.ViewModels;
using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBase.ApplicationServices.ModelConversions
{
    public static class ConversionHelper
    {
        public static TestQuestionAnswerViewModel ConvertToViewModel(this IEnumerable<TestQuestionAnswer> testQuestionAnswers)
        {
            TestQuestionAnswerViewModel testQuestionAnswerViewModel = new TestQuestionAnswerViewModel { QuesitonViewModels = new List<QuestionViewModel>() };

            QuestionViewModel questionViewModel = new QuestionViewModel();
            List<AnswerViewModel> answerViewModels = new List<AnswerViewModel>();
            foreach (var testQuestionAnswer in testQuestionAnswers)
            {
                answerViewModels.Add(new AnswerViewModel { AnswerId = testQuestionAnswer.AnswerId, AnswerText = testQuestionAnswer.AnswerText });

                if (questionViewModel.QuestionId != testQuestionAnswer.QuestionId)
                {
                    testQuestionAnswerViewModel = new TestQuestionAnswerViewModel { Id = testQuestionAnswer.TestId };
                    questionViewModel.AnswerViewModels = answerViewModels;
                    testQuestionAnswerViewModel.QuesitonViewModels.Add(questionViewModel);
                }

                questionViewModel = new QuestionViewModel { QuestionId = testQuestionAnswer.QuestionId, QuestionText = testQuestionAnswer.QuestionText };
            }

            return testQuestionAnswerViewModel;
        }
    }
}
