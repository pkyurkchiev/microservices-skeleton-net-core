using KnowledgeBase.Data;
using KnowledgeBase.Data.Entities.Enums;
using KnowledgeBase.Data.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, ISoftDelete
    {
        #region Constructors
        public Repository(KnowledgeBaseDbContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            this.DbSet = this.Context.Set<T>();
        }

        #endregion

        //To DO Async Methods :)

        #region Properties

        protected DbSet<T> DbSet { get; set; }

        protected KnowledgeBaseDbContext Context { get; set; }

        public virtual async Task<IList<T>> GetAll(DeleteStatus deleteStatus = DeleteStatus.NotDeleted)
        {
            var query = this.DbSet.AsQueryable();

            return await SoftDeleteQueryFilter(query, deleteStatus).ToListAsync();
        }

        #endregion

        #region Methods

        public virtual async Task<T> GetById(object id, DeleteStatus deleteStatus = DeleteStatus.NotDeleted)
        {
            return await this.DbSet.FindAsync(id);
        }

        public virtual async Task Insert(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                await this.DbSet.AddAsync(entity);
            }
        }

        public virtual void Update(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            entity.IsDeleted = true;
            this.Update(entity);
        }

        public virtual async Task Delete(object id)
        {
            var entity = await this.GetById(id);

            if (entity != null)
            {
                entity.IsDeleted = true;
                this.Update(entity);
            }
        }

        public virtual void PermanentDelete(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual async Task PermanentDelete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                await this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }

        public virtual async Task<IList<T>> Find(Expression<Func<T, bool>> where, DeleteStatus deleteStatus = DeleteStatus.NotDeleted)
        {
            var query = this.DbSet.Where(where);
            return await SoftDeleteQueryFilter(query, deleteStatus).ToListAsync();
        }

        #endregion

        #region Private Methods

        private IQueryable<T> SoftDeleteQueryFilter(IQueryable<T> query, DeleteStatus deleteStatus)
        {
            if (deleteStatus == DeleteStatus.NotDeleted)
            {
                query = query.Where(x => !x.IsDeleted);
            }
            else if (deleteStatus == DeleteStatus.Deleted)
            {
                query = query.Where(x => x.IsDeleted);
            }

            return query;
        }

        #endregion
    }
}
