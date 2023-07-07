using EmploymentForm.API.DTO;
using EmploymentForm.API.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentForm.API.Controllers
{
    [Route("api/formField")]
    [ApiController]
    public class FormFieldController : ControllerBase
    {
        private readonly IFormField _formField;

        public FormFieldController( IFormField formField)
        {
            _formField = formField;
        }

        [HttpGet]
        [Route("get_form")]
        public IActionResult GetAllDetails()
        {
            var result = _formField.GetAllDetails();
            return Ok(result);
        }

        [HttpPost]
        [Route("fill_form")]
        public async Task<IActionResult> FillForm([FromForm] FormFieldDTO formField)
        {
            var result = await _formField.AddEmploymentField(formField);
            return Ok(result);
        }
    }
}
