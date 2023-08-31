using EmploymentFormWeb.Models;
using EmploymentFormWeb.Services.IServices;

namespace EmploymentFormWeb.Services
{
    public class FormServices : BaseService, IFormService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FormServices(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClientFactory = httpClient;
        }

        public async Task<T> CreateFormAsync<T>(FormDto formDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = formDto,
                Url = SD.FormAPIBase + "/api/formField",
                AccessToken = ""
            });
        }

        public async Task<T> GetAllFormDetailsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.FormAPIBase + "/api/formField",
                AccessToken = ""
            });
        }
    }
}
