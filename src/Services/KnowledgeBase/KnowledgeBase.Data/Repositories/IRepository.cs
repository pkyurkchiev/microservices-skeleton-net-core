using KnowledgeBase.Data.Entities.Enums;
using KnowledgeBase.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KnowledgeBase.Data.Repositories
{
    public interface IRepository<T> where T : class , ISoftDelete
    {
        Task<IEnumerable<T>> GetAll(DeleteStatusEnum DeleteStatus = DeleteStatusEnum.NotDeleted);

        Task<T> GetById(object id, DeleteStatusEnum DeleteStatus = DeleteStatusEnum.NotDeleted);

        Task Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task Delete(object id);

        void Detach(T entity);

        Task PermanentDelete(object id);

        void PermanentDelete(T entity);

        Task<IList<T>> Find(Expression<Func<T, bool>> where, DeleteStatusEnum DeleteStatus = DeleteStatusEnum.NotDeleted);
    }
}
