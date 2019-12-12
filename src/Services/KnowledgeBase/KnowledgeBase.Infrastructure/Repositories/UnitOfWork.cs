using KnowledgeBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace KnowledgeBase.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        #endregion

        #region Constructors

        public UnitOfWork(KnowledgeBaseDbContext context)
        {
            this.Context = context;
        }

        #endregion

        #region Methods
        
        public KnowledgeBaseDbContext Context { get; }

        public int SaveChanges() => this.Context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await this.Context.SaveChangesAsync();

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            Type modelType = typeof(TRepository);

            if (!repositories.ContainsKey(modelType))
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                var types = asm.GetTypes().Where(x => x.IsClass
                                                      && !x.IsAbstract
                                                      && modelType.IsAssignableFrom(x)
                    );

                TRepository returnVar = null;
                foreach (Type x in types)
                {
                    ConstructorInfo[] mi = x.GetConstructors();
                    returnVar = (TRepository)Activator.CreateInstance(x.UnderlyingSystemType, new object[] { Context });
                }

                if (returnVar != null)
                {
                    lock (repositories)
                        repositories.Add(modelType, returnVar);
                    return returnVar;
                }
            }

            return (TRepository)repositories[modelType];
        }

        public void Dispose() => this.Dispose(true);
        #endregion

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                }
            }
        }
    }
}
