using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Context;
using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDbContext _context;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
           
          _context.Remove(t);
          _context.SaveChanges(); 
        }

        public T GetById(int id)
        {
            return  _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}
