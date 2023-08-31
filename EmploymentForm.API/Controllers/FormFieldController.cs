using EmploymentForm.API.DTO;
using EmploymentForm.API.Infrastructure.Interface;
using EmploymentForm.API.ReadOnly;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentForm.API.Controllers
{
    [Route("api/formField")]
    [ApiController]
    public class FormFieldController : ControllerBase
    {
        protected ResponseDto _response;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFormField _formField;

        public FormFieldController( IFormField formField, IWebHostEnvironment webHostEnvironment)
        {
            _formField = formField;
            this._response = new ResponseDto();
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        //[Route("get_form")]

        //public  IActionResult GetAllDetails()
        //{
        //    try
        //    {
        //        IEnumerable<FormFieldDto> formFieldDtos = (IEnumerable<FormFieldDto>)_formField.GetAllDetails();
        //        _response.Result = formFieldDtos;

        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessage = new List<string>() { ex.ToString() };
        //    }
        //    return (IActionResult)_response;
        //}
        public IActionResult GetAllDetails()
        {
            try
            {
                var result = _formField.GetAllDetails();
                foreach (var item in result)
                {
                    item.SelfiePhoto = $"{_webHostEnvironment.WebRootPath}/{item.SelfiePhoto}";
                    item.UploadFrontID = $"{_webHostEnvironment.WebRootPath}/{item.UploadFrontID}";
                    item.UploadBackID = $"{_webHostEnvironment.WebRootPath}/{item.UploadBackID}";
                }
                _response.Result = result;

                return Ok(_response); // Assuming you want to return the _response object
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };

                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
            return Ok(_response);
            
        }

        [HttpPost]
       // [Route("fill_form")]
        public async Task<IActionResult> FillForm([FromForm] FormFieldDTO formField)
        {
            var result = await _formField.AddEmploymentField(formField);
            return Ok(result);
        }
    }
}
