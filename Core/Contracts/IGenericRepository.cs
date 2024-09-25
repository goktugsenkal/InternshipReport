using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<IReadOnlyList<T>> FindAll();
        Task<IReadOnlyList<T>> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(int id);
        Task<int> Count(Expression<Func<T, bool>> expression);

        void Save();
    }
}