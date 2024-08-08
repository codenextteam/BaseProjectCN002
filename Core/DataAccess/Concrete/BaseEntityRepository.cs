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
    public class BaseEntityRepository<TEntity, TContext>(TContext context) : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context = context;
        public void Add(TEntity entity)
        {
           
            var addedEntiry = _context.Entry(entity);
            addedEntiry.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
          
            var removedEntiry = _context.Entry(entity);
            removedEntiry.State = EntityState.Modified;
            _context.SaveChanges();
        }

     

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
        
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

      

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
         
             return filter == null? _context.Set<TEntity>().ToList() : _context.Set<TEntity>().Where(filter).ToList();
        }

        public void Update(TEntity entity)
        {
           
            var updateEntiry = _context.Entry(entity);
            updateEntiry.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
