using KnowledgeBase.ApplicationServices.ViewModels;
using KnowledgeBase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnowledgeBase.ApplicationServices.ModelConversions
{
    public static class ConversionHelper
    {
        public static TestViewModel ConvertToViewModel(this Test test)
        {
            return new TestViewModel()
            {
            };
        }

        public static IEnumerable<TestViewModel> ConvertToViewModels(this IEnumerable<Test> tests)
        {
            List<TestViewModel> testViewModels = new List<TestViewModel>();
            foreach (Test test in tests)
            {
                testViewModels.Add(test.ConvertToViewModel());
            }
            return testViewModels;
        }
    }
}
