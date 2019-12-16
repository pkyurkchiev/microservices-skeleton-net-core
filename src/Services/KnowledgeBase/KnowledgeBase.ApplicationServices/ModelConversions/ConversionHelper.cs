using KnowledgeBase.ApplicationServices.ViewModels;
using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeBase.ApplicationServices.ModelConversions
{
    public static class ConversionHelper
    {
        public static TestQuestionAnswerViewModel ConvertToViewModel(this IEnumerable<TestQuestionAnswer> testQuestionAnswers)
        {
            TestQuestionAnswerViewModel testQuestionAnswerViewModel = new TestQuestionAnswerViewModel();

            QuestionViewModel questionViewModel = new QuestionViewModel();
            List<AnswerViewModel> answerViewModels = new List<AnswerViewModel>();
            var testQuestionAnswerList = testQuestionAnswers.ToList();
            //foreach (var testQuestionAnswer in testQuestionAnswers)
            for (int i = 0; i < testQuestionAnswerList.Count(); i++)
            {
                if (testQuestionAnswerViewModel.Id == Guid.Empty)
                    testQuestionAnswerViewModel = new TestQuestionAnswerViewModel { Id = testQuestionAnswerList[i].TestId };

                if (questionViewModel.QuestionId != Guid.Empty && questionViewModel.QuestionId != testQuestionAnswerList[i].QuestionId)
                {
                    questionViewModel.AnswerViewModels = answerViewModels;
                    testQuestionAnswerViewModel.QuesitonViewModels.Add(questionViewModel);
                    answerViewModels = new List<AnswerViewModel>();
                }

                answerViewModels.Add(new AnswerViewModel { AnswerId = testQuestionAnswerList[i].AnswerId, AnswerText = testQuestionAnswerList[i].AnswerText });
                if (testQuestionAnswerList.Count() - 1 == i)
                {
                    questionViewModel.AnswerViewModels = answerViewModels;
                    testQuestionAnswerViewModel.QuesitonViewModels.Add(questionViewModel);
                    break;
                }
                questionViewModel = new QuestionViewModel { QuestionId = testQuestionAnswerList[i].QuestionId, QuestionText = testQuestionAnswerList[i].QuestionText };
            }

            return testQuestionAnswerViewModel;
        }
    }
}
