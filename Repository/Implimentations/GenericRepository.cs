﻿using Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal BookShop2SystemDBContext context;
        internal DbSet<TEntity> dbSet;

        // Constructor 
        public GenericRepository(BookShop2SystemDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        //Getting list of entities with filter and orderby
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
        // SEARCH //
        public virtual List<TEntity> GetByQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        // Get entity by id
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        // insert entity 
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        // delete entity with id
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        // delete entity with whole object
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        // update entity
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }


    }
}