using EmploymentFormWeb.Models;

namespace EmploymentFormWeb.Services.IServices
{
    public interface IFormService : IBaseService
    {
        Task<T> GetAllFormDetailsAsync<T>();
        Task<T> CreateFormAsync<T>(FormDto formDto);
    }
}
