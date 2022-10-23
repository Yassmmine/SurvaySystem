using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SurvaySystem.DomainProject.Entities;

namespace SurvaySystem.Infrastructure
{
    public class SurvaySystemDBContext : DbContext
    {
        public SurvaySystemDBContext(DbContextOptions<SurvaySystemDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<TBlKPI> TblKPIS { get; set; }
    }
}
