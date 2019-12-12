using KnowledgeBase.Data;
using KnowledgeBase.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(KnowledgeBaseDbContext context) : base(context)
        { }

        public async Task GenerateTests()
        {
            Guid userIdTemp = new Guid();
            using (DbCommand command = Context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"SELECT g1.UserId as UserId,
                                           ISNULL(a.QuestionId, g1.QuestionId) AS QuestionId,
                                           g1.Question AS QuestionText,
                                           a.Id AS AnswerId,
                                           a.TEXT AS AnswerText
                                    FROM Answers a
                                    INNER JOIN
                                      (SELECT a.UserId,
                                              a.QuestionId,
                                              a.Question,
                                              a.CorrectAnswerId
                                       FROM
                                         (SELECT u.Id AS UserId,
                                                 q.Id AS QuestionId,
                                                 q.Text AS Question,
                                                 q.CorrectAnswerId,
                                                 ROW_NUMBER() OVER (PARTITION BY u.Id
                                                                    ORDER BY CRYPT_GEN_RANDOM(10) DESC) AS RNO
                                          FROM Users u
                                          CROSS
                                              JOIN Questions q) a
                                       WHERE RNO <= 5 ) g1 ON (a.QuestionId = g1.QuestionId)
                                    OR (g1.CorrectAnswerId = a.Id)
                                    ORDER BY UserId,
                                             Question,
                                             CRYPT_GEN_RANDOM(10)";
                await Context.Database.OpenConnectionAsync();
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Test> test = await this.DbSet.AddAsync(new Test());
                    while (await reader.ReadAsync())
                    {
                        if (userIdTemp != reader.GetGuid(0))
                        {
                            test = await this.DbSet.AddAsync(new Test());
                            this.Context.Entry(new UserTest { UserId = reader.GetGuid(0), TestId = test.Entity.Id }).State = EntityState.Added;
                        }
                        this.Context.Entry(new TestQuestionAnswer { TestId = test.Entity.Id, QuestionId = reader.GetGuid(1), AnswerId = reader.GetGuid(3), CreatedOn = DateTime.UtcNow }).State = EntityState.Added;

                        userIdTemp = reader.GetGuid(0);
                    }
                }
            }
        }
    }
}
