using KnowledgeBase.Data.Entities;
using KnowledgeBase.Data.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace KnowledgeBase.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        #endregion

        #region Constructors

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public IRepository<Answer> Answers
        {
            get
            {
                return this.GetRepository<Answer>();
            }
        }

        public IRepository<Department> Departments
        {
            get
            {
                return this.GetRepository<Department>();
            }
        }

        public IRepository<DifficultyLevel> Levels
        {
            get
            {
                return this.GetRepository<DifficultyLevel>();
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                return this.GetRepository<Question>();
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return this.GetRepository<Role>();
            }
        }

        public IRepository<Test> Tests
        {
            get
            {
                return this.GetRepository<Test>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Task> Tasks
        {
            get
            {
                return this.GetRepository<Task>();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public int Commit()
        {
            return this.context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        #endregion

        #region Private Methods

        private IRepository<T> GetRepository<T>() where T : class , ISoftDelete
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        #endregion
    }
}
