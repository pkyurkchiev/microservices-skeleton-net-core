using KnowledgeBase.Data.Entities.Enums;
using KnowledgeBase.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class , ISoftDelete
    {
        Task<IList<T>> GetAll(DeleteStatus DeleteStatus = DeleteStatus.NotDeleted);

        Task<T> GetById(object id, DeleteStatus DeleteStatus = DeleteStatus.NotDeleted);

        Task Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task Delete(object id);

        void Detach(T entity);

        Task PermanentDelete(object id);

        void PermanentDelete(T entity);

        Task<IList<T>> Find(Expression<Func<T, bool>> where, DeleteStatus DeleteStatus = DeleteStatus.NotDeleted);
    }
}
