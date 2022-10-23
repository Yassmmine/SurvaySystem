
using Microsoft.EntityFrameworkCore;
using SurvaySystem.DomainProject.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace SurvaySystem.Infrastructure.Configuration
{
    public class TblKPIConfiguration : IEntityTypeConfiguration<TBlKPI>
    {
        public void Configure(EntityTypeBuilder<TBlKPI> TblKPI)
        {
            TblKPI.HasKey(c => c.Id);
            TblKPI.Property(c => c.KPIDescription).IsRequired().HasMaxLength(150);
        }

    }
}
