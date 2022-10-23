using Microsoft.EntityFrameworkCore;
using SurvaySystem.ApplicationProject.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SurvaySystem.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly SurvaySystemDBContext _dbContext;
        public UnitOfWork(SurvaySystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void RollBack()
        {
            _dbContext.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
        }
    }
}

