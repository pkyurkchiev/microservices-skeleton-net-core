using KnowledgeBase.Data.Entities;
using KnowledgeBase.Data.Entities.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Data.Repositories
{
    public class TestDetailRepository : Repository<TestDetail>, ITestDetailRepository
    {
        public TestDetailRepository(KnowledgeBaseDbContext context) : base(context)
        { }

        public async Task<IList<TestDetail>> GetByTestId(Guid testId)
        {
            var testDetails = await (from testDetail in Context.TestDetails
                                     join test in Context.Tests on testDetail.TestId equals test.Id
                                     where test.Id.Equals(testId)
                                     select testDetail).ToListAsync();
            return testDetails;
        }

        public async Task<IList<TestDetail>> GetByUserExternalId(string userExternalId)
        {
            var testDetails = await (from TestDetail in Context.TestDetails
                                     join test in Context.Tests on TestDetail.TestId equals test.Id
                                     where test.UserTests.Any(x => x.User.ExternalId.Equals(userExternalId))
                                     select TestDetail).ToListAsync();
            return testDetails;
        }

        public async Task<IList<TestDetail>> GetTestResults(Guid testId)
        {
            var testDetails = await (from TestDetail in Context.TestDetails
                                     join test in Context.Tests on TestDetail.TestId equals test.Id
                                     where test.Id == testId
                                     select TestDetail).ToListAsync();
            return testDetails;
        }


        public async Task MarkAnswer(Guid testId, Guid questionId, Guid answerId, Guid externalUserId)
        {
            var testDetails = await base.DbSet.Where(x => x.TestId == testId && x.QuestionId == questionId).ToListAsync();
            foreach (var testDetail in testDetails)
            {
                if (testDetail.AnswerId == answerId)
                {
                    testDetail.MarkAnswer = true;
                    testDetail.UpdatedBy = externalUserId;
                    testDetail.UpdateOn = DateTime.UtcNow;
                }
                else
                {
                    testDetail.MarkAnswer = false;
                }
            }
        }

        public async Task GenerateTests(Guid disciplineId, string description, Guid userId)
        {
            Guid userIdTemp = new Guid();
            DateTime dateNow = DateTime.UtcNow;
            using (DbCommand command = Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT g1.userid                            AS UserId, 
                                               Isnull(a2.questionid, g1.questionid) AS QuestionId, 
                                               g1.question                          AS QuestionText, 
                                               a2.id                                AS AnswerId, 
                                               a2.text                              AS AnswerText, 
                                               g1.correctanswerid, 
                                               CASE 
                                                 WHEN a2.id = g1.correctanswerid THEN CAST(1 as bit) 
                                                 ELSE CAST(0 as bit)
                                               END                                  CorrectAnswer 
                                        FROM   answers a2 
                                               INNER JOIN (SELECT a.userid, 
                                                                  a.questionid, 
                                                                  a.question, 
                                                                  a.correctanswerid 
                                                           FROM   (SELECT u.id                                    AS 
                                                                          UserId, 
                                                                          q.id                                    AS 
                                                                          QuestionId 
                                                                          , 
                                                                          q.text 
                                                                          AS Question, 
                                                                          q.correctanswerid, 
                                                                          Row_number() 
                                                                            OVER ( 
                                                                              partition BY u.id 
                                                                              ORDER BY Crypt_gen_random(10) DESC) AS RNO 
                                                                   FROM   users u 
                                                                          CROSS JOIN (SELECT *FROM questions where DisciplineId = @disciplineId) q) a 
                                                           WHERE  rno <= 5) g1 
                                                       ON ( a2.questionid = g1.questionid ) 
                                                           OR ( g1.correctanswerid = a2.id ) 
                                        ORDER  BY userid, 
                                                  question, 
                                                  Crypt_gen_random(10)";
                command.Parameters.Add(new SqlParameter("@disciplineId", disciplineId));
                await Context.Database.OpenConnectionAsync();
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Test> test = await this.Context.Tests.AddAsync(new Test() { CreateBy = userId, CreatedOn = dateNow, Description = description, DisciplineId = disciplineId, Status = TestStatusEnum.Created });
                    while (await reader.ReadAsync())
                    {
                        if (userIdTemp != reader.GetGuid(0))
                        {
                            test = await this.Context.Tests.AddAsync(new Test() { CreateBy = userId, CreatedOn = dateNow, Description = description, DisciplineId = disciplineId, Status = TestStatusEnum.Created });
                            this.Context.Entry(new UserTest { UserId = reader.GetGuid(0), TestId = test.Entity.Id }).State = EntityState.Added;
                        }
                        this.Context.Entry(new TestDetail { Id = Guid.NewGuid(), TestId = test.Entity.Id, QuestionId = reader.GetGuid(1), QuestionText = reader.GetString(2), AnswerId = reader.GetGuid(3), AnswerText = reader.GetString(4), CorrectAnswer = reader.GetBoolean(6), MarkAnswer = false, CreateBy = userId, CreatedOn = dateNow }).State = EntityState.Added;

                        userIdTemp = reader.GetGuid(0);
                    }
                }
            }
        }
    }
}
