using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T>
    //
    where T : BaseEntity
    //
    {
        protected readonly ReportDbContext _context;

        public GenericRepository(ReportDbContext context)
        {
            _context = context;
        }

        public async Task<int> Count(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().CountAsync(expression);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public bool Exists(int id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
            // where  T : BaseEntity kullandığımız için elimizde "e.Id" var.
        }

        public async Task<IReadOnlyList<T>> FindAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public void Update(T entity)
        {   
            _context.Set<T>().Update(entity);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}