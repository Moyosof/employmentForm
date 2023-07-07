using EmploymentFormWeb.Services;
using EmploymentFormWeb.Services.IServices;

namespace EmploymentFormWeb
{
    public static class ServiceExtension
    {
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IFormService, FormServices>();
            SD.FormAPIBase = configuration["ServiceUrls:FormFieldAPI"];

            services.AddScoped<IFormService, FormServices>();
        }
    }
}
