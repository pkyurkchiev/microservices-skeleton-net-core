using KnowledgeBase.ApplicationServices.ViewModels;
using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeBase.ApplicationServices.ModelConversions
{
    public static class ConversionHelper
    {
        public static TestDetailViewModel ConvertToViewModel(this IEnumerable<TestDetail> testQuestionAnswers)
        {
            TestDetailViewModel testQuestionAnswerViewModel = new TestDetailViewModel();

            QuestionViewModel questionViewModel = new QuestionViewModel();
            List<AnswerViewModel> answerViewModels = new List<AnswerViewModel>();
            var testQuestionAnswerList = testQuestionAnswers.ToList();
            //foreach (var testQuestionAnswer in testQuestionAnswers)
            for (int i = 0; i < testQuestionAnswerList.Count(); i++)
            {
                if (testQuestionAnswerViewModel.Id == Guid.Empty)
                    testQuestionAnswerViewModel = new TestDetailViewModel { Id = testQuestionAnswerList[i].TestId };

                if (questionViewModel.QuestionId != Guid.Empty && questionViewModel.QuestionId != testQuestionAnswerList[i].QuestionId)
                {
                    questionViewModel.AnswerViewModels = answerViewModels;
                    testQuestionAnswerViewModel.QuestionViewModels.Add(questionViewModel);
                    answerViewModels = new List<AnswerViewModel>();
                }

                answerViewModels.Add(new AnswerViewModel { AnswerId = testQuestionAnswerList[i].AnswerId, AnswerText = testQuestionAnswerList[i].AnswerText, MarkAnswer = testQuestionAnswerList[i].MarkAnswer });
                if (testQuestionAnswerList.Count() - 1 == i)
                {
                    questionViewModel.AnswerViewModels = answerViewModels;
                    testQuestionAnswerViewModel.QuestionViewModels.Add(questionViewModel);
                    break;
                }
                questionViewModel = new QuestionViewModel { QuestionId = testQuestionAnswerList[i].QuestionId, QuestionText = testQuestionAnswerList[i].QuestionText };
            }

            return testQuestionAnswerViewModel;
        }
    }
}
