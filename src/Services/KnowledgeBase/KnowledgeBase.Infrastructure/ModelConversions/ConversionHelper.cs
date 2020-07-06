using KnowledgeBase.Infrastructure.ViewModels;
using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeBase.Infrastructure.ModelConversions
{
    public static class ConversionHelper
    {
        public static TestDetailViewModel ConvertToViewModel(this IEnumerable<TestDetail> testQuestionAnswers)
        {
            TestDetailViewModel testQuestionAnswerViewModel = new TestDetailViewModel();

            QuestionViewModel questionViewModel = new QuestionViewModel();
            List<AnswerViewModel> answerViewModels = new List<AnswerViewModel>();
            var testQuestionAnswerList = testQuestionAnswers.ToList();
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

        public static TestDetailResultViewModel ConvertToViewModelResult(this IEnumerable<TestDetail> testQuestionAnswers)
        {
            TestDetailResultViewModel testQuestionAnswerViewModel = new TestDetailResultViewModel();

            QuestionResultViewModel questionViewModel = new QuestionResultViewModel();
            List<AnswerResultViewModel> answerViewModels = new List<AnswerResultViewModel>();
            var testQuestionAnswerList = testQuestionAnswers.ToList();
            for (int i = 0; i < testQuestionAnswerList.Count(); i++)
            {
                if (testQuestionAnswerViewModel.Id == Guid.Empty)
                    testQuestionAnswerViewModel = new TestDetailResultViewModel { Id = testQuestionAnswerList[i].TestId };

                if (questionViewModel.QuestionId != Guid.Empty && questionViewModel.QuestionId != testQuestionAnswerList[i].QuestionId)
                {
                    questionViewModel.AnswerResultViewModels = answerViewModels;
                    testQuestionAnswerViewModel.QuestionResultViewModels.Add(questionViewModel);
                    answerViewModels = new List<AnswerResultViewModel>();
                }

                answerViewModels.Add(new AnswerResultViewModel { AnswerId = testQuestionAnswerList[i].AnswerId, AnswerText = testQuestionAnswerList[i].AnswerText, MarkAnswer = testQuestionAnswerList[i].MarkAnswer, CorrectAnswer = testQuestionAnswerList[i].CorrectAnswer });
                if (testQuestionAnswerList.Count() - 1 == i)
                {
                    questionViewModel.AnswerResultViewModels = answerViewModels;
                    testQuestionAnswerViewModel.QuestionResultViewModels.Add(questionViewModel);
                    break;
                }
                questionViewModel = new QuestionResultViewModel { QuestionId = testQuestionAnswerList[i].QuestionId, QuestionText = testQuestionAnswerList[i].QuestionText, MarkOn = testQuestionAnswerList[i].UpdateOn };
            }

            return testQuestionAnswerViewModel;
        }
    }
}
