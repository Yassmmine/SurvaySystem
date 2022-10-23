using Microsoft.Extensions.DependencyInjection;
using SurvaySystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SurvaySystem.ApplicationProject.Interfaces;
using SurvaySystem.ApplicationProject.Interfaces.Service;
using SurvaySystem.ApplicationProject.Service;
using SurvaySystem.ApplicationProject.Interfaces.Repository;
using SurvaySystem.Infrastructure.Repository;
namespace MVC
{
    public partial class Startup
    {
        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<SurvaySystemDBContext>(options =>
                 options.UseLazyLoadingProxies()
                 .UseSqlServer(Configuration.GetConnectionString("SurvaySystemDBContext")));
        }
        private void ConfigureServiceTypes(IServiceCollection services)
        {
            services.AddScoped(typeof(ITblKPIService), typeof(TblKPIService));
          
        }

        private static void ConfigureRepositoriesTypes(IServiceCollection services)
        {
            services.AddScoped(typeof(ITBlKPIRepository), typeof(TBIKPIRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }

    }
}
