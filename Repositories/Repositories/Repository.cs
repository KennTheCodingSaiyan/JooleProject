using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);
        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        public Repository (DbContext context)
        {
            this.context = context;
        }
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity GetByID(int id)
        {
            //throw new NotImplementedException();
            return context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}