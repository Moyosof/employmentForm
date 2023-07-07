using EmploymentFormWeb.Models;

namespace EmploymentFormWeb.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
