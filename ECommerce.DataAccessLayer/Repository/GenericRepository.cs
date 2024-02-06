using ECommerce.Common.Enums;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Context;
using ECommerce.DataAccessLayer.EntityFramework;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<T> _dbSet;
       
        
        public GenericRepository(ECommerceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
           
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            
        }

        public void Delete(T entity)
        {
           _context.Remove(entity);
            _context.SaveChanges();
            
        }

        
        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {

            

            var query = _context.Set<T>().AsQueryable();


            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);

            }

            var a =  await query.Where(predicate).ToListAsync();
            return a;
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includeProperties)
          
        {
            return await _dbSet.Where(expression).ToListAsync();
        }


        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

		public List<T> GetAll()
		{
			return _context.Set<T>().ToList();
		}

		public void Update(T entity)
        {
           _context.Update(entity);
           _context.SaveChanges();
        }

        public async Task<T> FilterAsyncData(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var result = await query.FirstOrDefaultAsync(predicate);
            return result;
        }

    }
}
