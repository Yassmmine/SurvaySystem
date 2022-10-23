using Microsoft.EntityFrameworkCore;
using SurvaySystem.ApplicationProject.Interfaces.Repository;
using SurvaySystem.DomainProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SurvaySystem.Infrastructure.Repository
{
    public class BaseRepository<T, YDbContext, IdType> : IBaseRepository<T, IdType> where T : BaseEntity<IdType> where YDbContext : DbContext
    {
        protected readonly YDbContext _dbContext;


        public BaseRepository(YDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return await _dbContext.Set<T>().Where(a=>!a.IsDeleted).ToListAsync();
            else
                return await _dbContext.Set<T>().Where(a => !a.IsDeleted).Where(predicate).ToListAsync();
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbContext.Set<T>().Where(a => !a.IsDeleted).ToList();
            else
                return _dbContext.Set<T>().Where(a => !a.IsDeleted).Where(predicate).ToList();
        }

        public virtual bool HasAny(Expression<Func<T, bool>> predicate = null)
        {
            return _dbContext.Set<T>().Where(a => !a.IsDeleted).Any(predicate);
        }

        public virtual async Task<long> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await _dbContext.Set<T>().Where(a => !a.IsDeleted).CountAsync(predicate);
        }

        public virtual IQueryable<T> GetAllDescendingAsync<Y>(Expression<Func<T, Y>> sort, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _dbContext.Set<T>().Where(a => !a.IsDeleted).OrderByDescending(sort).AsQueryable();
            else
                return _dbContext.Set<T>().Where(a => !a.IsDeleted).Where(predicate).OrderByDescending(sort).AsQueryable();
        }

      

        public async Task<List<T>> ToListAsync(IQueryable<T> query)
        {
            return await query.ToListAsync();
        }

        public virtual T FindByID(IdType Id)
        {
            return _dbContext.Set<T>().FirstOrDefault(z => z.Id.Equals(Id));
        }
        public virtual void Create(T obj)
        {
            _dbContext.Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Added;
        }

        public void CreateRange(IEnumerable<T> objs)
        {
            _dbContext.Set<T>().AddRange(objs);
        }

        public void Delete(params IdType[] idList)
        {
            _dbContext.Set<T>().Where(z => idList.Contains(z.Id)).ForEachAsync(delegate (T item)
            {
                item.IsDeleted = true;
            });
        }
        public void Delete(T obj)
        {
            obj.IsDeleted = true;
        }
        public void Update(T obj, params string[] excludedFields)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            foreach (string fld in excludedFields)
                _dbContext.Entry(obj).Property(fld).IsModified = false;
        }

      
    }

}
