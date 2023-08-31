using EmploymentFormWeb.Models;
using EmploymentFormWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmploymentFormWeb.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;
        private readonly IHttpClientFactory _httpClientFactory;

        public FormController(IFormService formService, IHttpClientFactory httpClientFactory)
        {
            _formService = formService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult>  FormIndex()
        {
            try
            {
                
                var httpClient = _httpClientFactory.CreateClient("UserApiClient");
                httpClient.BaseAddress = new Uri("https://localhost:44392/");
                var response = await httpClient.GetAsync("GetAllDetails");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ResponseDto>(responseContent);

                    if (apiResponse.IsSuccess)
                    {
                        var forms = JsonConvert.DeserializeObject<List<GetFormDto>>(Convert.ToString(apiResponse.Result));
                        return View(forms);
                    }
                    else
                    {
                        // Handle the API error if needed
                        // You can access apiResponse.ErrorMessage to get the error message
                    }
                }
                else
                {
                    // Handle the API error if needed
                    // You can access response.StatusCode and response.ReasonPhrase to get the error details
                }
            }
            catch (Exception ex)
            {
                // Handle the exception if needed
                // Log the exception or return an error view
            }

            return View();


           // List<GetFormDto> forms = new();
            //var result = await _formService.GetAllFormDetailsAsync<ResponseDto>();
            //if (result != null && result.IsSuccess)
            //{
            //    forms = JsonConvert.DeserializeObject<List<GetFormDto>>(Convert.ToString(result.Result));

            //}
            //string baseUrl = "https://localhost:44392";
            //foreach (var form in forms)
            //{
            //    form.SelfiePhoto = $"{baseUrl}/EmploymentFormWeb.API/wwwroot/FormImages/selfie/{form.SelfiePhoto}";
            //    form.UploadFrontID = $"{baseUrl}/wwwroot/FormImages/uploadFront/{form.UploadFrontID}";
            //    form.UploadBackID = $"{baseUrl}/FormImages/{form.UploadBackID}";
            //}
            //return View(forms);
        }
        public IActionResult FormCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormCreate(FormDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _formService.CreateFormAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(FormSuccess));
                }
            }

            return View(model);
        }

        public IActionResult FormSuccess() 
        {
            return View();
        }
    }
}
