using Core.DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class BaseEntityRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
           using var context = new TContext();
            var addedEntiry = context.Entry(entity);
            addedEntiry.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var removedEntiry = context.Entry(entity);
            removedEntiry.State = EntityState.Modified;
            context.SaveChanges();
        }

     

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

      

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using TContext context = new TContext();
             return filter == null? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var updateEntiry = context.Entry(entity);
            updateEntiry.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
