using SurvaySystem.DomainProject.Entities;
using SurvaySystem.ApplicationProject.Interfaces.Repository;

namespace SurvaySystem.Infrastructure.Repository
{
    public class TBIKPIRepository : BaseRepository<TBlKPI, SurvaySystemDBContext, int>, ITBlKPIRepository
    {
        public TBIKPIRepository(SurvaySystemDBContext survaySystemDB) :base(survaySystemDB)
        {
        }
    }
}
