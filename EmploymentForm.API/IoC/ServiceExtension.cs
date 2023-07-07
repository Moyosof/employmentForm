using EmploymentForm.API.Data;
using EmploymentForm.API.Infrastructure.Contract;
using EmploymentForm.API.Infrastructure.Interface;
using EmploymentForm.API.Repository.Implementation;
using EmploymentForm.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmploymentForm.API.IoC
{
    public static class ServiceExtension
    {
        #region DATA CONTEXT
        public static void ConfigureConnectionString(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer
            (configuration.GetConnectionString("DefaultConnection")));
        }
        #endregion

        #region INTERFACE CONFIGURATION
        public static void ConfigureRepository(this IServiceCollection services )
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IFormField, FormFieldService>();
        }
        #endregion
    }
}
