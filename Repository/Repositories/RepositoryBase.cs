using Contract.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly APIDbContext Context;
        public RepositoryBase(APIDbContext repositoryContext)
        {
            Context = repositoryContext;
        }
        public void Create(TEntity entity) => Context.Set<TEntity>().Add(entity);

        public void Delete(int id) => Context.Remove(id);

        public IEnumerable<TEntity> GetAll() => Context.Set<TEntity>().ToList();

        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

        public TEntity Get(int id) => Context.Set<TEntity>().Find(id)!;
    }
}
