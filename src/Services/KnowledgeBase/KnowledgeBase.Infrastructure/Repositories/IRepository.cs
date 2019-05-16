using KnowledgeBase.Data.Entities.Enums;
using KnowledgeBase.Data.Entities.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace KnowledgeBase.Infrastructure.Repository
{
    public interface IRepository<T> where T : class , ISoftDelete
    {
        IQueryable<T> GetAll(DeleteStatus DeleteStatus = DeleteStatus.NotDeleted);

        T GetById(object id, DeleteStatus DeleteStatus = DeleteStatus.NotDeleted);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        void Detach(T entity);

        void PermanentDelete(object id);

        void PermanentDelete(T entity);

        IQueryable<T> Find(Expression<Func<T, bool>> where, DeleteStatus DeleteStatus = DeleteStatus.NotDeleted);
    }
}
