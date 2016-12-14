using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace SASSMMS.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal MainContext ObjiSIMSContextInternal;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(MainContext ObjiSIMSContext)
        {
            this.ObjiSIMSContextInternal = ObjiSIMSContext;
            this.dbSet = ObjiSIMSContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetByQuery(string sqlQuery)
        {
           return dbSet.SqlQuery(sqlQuery);
        }
        public virtual TEntity GetFirst()
        {
            return this.Get().First();
        }
        public virtual TEntity GetLast()
        {
            return this.Get().Last();
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (ObjiSIMSContextInternal.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            ObjiSIMSContextInternal.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
        }


        public virtual void Update(IEnumerable<TEntity> entitiesToUpdate)
        {
            foreach (TEntity entityToUpdate in entitiesToUpdate)
            {
                if (!dbSet.Contains(entityToUpdate))
                {
                    dbSet.Attach(entityToUpdate);
                    ObjiSIMSContextInternal.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
                }
            }
        }
    }
    
}
