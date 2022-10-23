using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SurvaySystem.ApplicationProject.Interfaces.Repository
{
    public interface IBaseRepository<T, R>
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAllDescendingAsync<Y>(Expression<Func<T, Y>> sort, Expression<Func<T, bool>> predicate = null);
        Task<List<T>> ToListAsync(IQueryable<T> query);
        bool HasAny(Expression<Func<T, bool>> predicate = null);
        Task<long> CountAsync(Expression<Func<T, bool>> predicate = null);
        T FindByID(R Id);
        //------------------------------
        void Create(T obj);
        void CreateRange(IEnumerable<T> objs);
        void Delete(params R[] idList);
        void Delete(T obj);
        void Update(T obj, params string[] excludedFields);

    }
}
