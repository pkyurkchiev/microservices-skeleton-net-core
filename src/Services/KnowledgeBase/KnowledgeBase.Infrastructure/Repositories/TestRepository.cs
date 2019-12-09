using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(DbContext context) : base(context)
        { }

        public async Task GenerateTests()
        {
            using DbCommand command = Context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "SELECT * From Table1";
            await Context.Database.OpenConnectionAsync();
            using (DbDataReader result = await command.ExecuteReaderAsync())
            {
                result[0].ToString();
            }
        }
    }
}
