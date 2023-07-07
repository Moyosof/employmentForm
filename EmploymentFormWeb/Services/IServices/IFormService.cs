using EmploymentFormWeb.Models;

namespace EmploymentFormWeb.Services.IServices
{
    public interface IFormService
    {
        Task<T> GetAllFormDetailsAsync<T>();
        Task<T> CreateFormAsync<T>(FormDto formDto);
    }
}
