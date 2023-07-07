using EmploymentFormWeb.Models;
using EmploymentFormWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmploymentFormWeb.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        public async Task<IActionResult>  FormIndex()
        {
            List<FormDto> forms = new();
            var result = await _formService.GetAllFormDetailsAsync<ResponseDto>();
            if(result != null && result.IsSuccess)
            {
                forms = JsonConvert.DeserializeObject<List<FormDto>>(Convert.ToString(result.Result));

            }
            return View(forms);
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
