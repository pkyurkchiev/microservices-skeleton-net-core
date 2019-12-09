using KnowledgeBase.Data.Entities;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public interface ITestRepository : IRepository<Test>
    {
        Task GenerateTests();
    }
}
