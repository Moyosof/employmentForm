using static EmploymentFormWeb.SD;

namespace EmploymentFormWeb.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.POST;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
