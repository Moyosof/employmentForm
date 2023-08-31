using EmploymentForm.API.Core;
using EmploymentForm.API.DTO;
using EmploymentForm.API.Infrastructure.Interface;
using EmploymentForm.API.ReadOnly;
using EmploymentForm.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EmploymentForm.API.Infrastructure.Contract
{
    public class FormFieldService : AbstractMethods, IFormField
    {
        private readonly IUnitOfWork<FormField> _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static string folderName = "FormImages";

        public FormFieldService(IUnitOfWork<FormField> unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<FormField> AddEmploymentField(FormFieldDTO formField)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            string folderPath = Path.Combine(webRootPath, folderName);

            string selfiePath = await CreateImage(formField.SelfiePhoto, folderPath, "selfie");
            string uploadFront = await CreateImage(formField.UploadFrontID, folderPath, "uploadFront");
            string uploadBack = await CreateImage(formField.UploadBackID, folderPath, "uploadBack");

            FormField field = new FormField()
            {
                Id = new Guid(),
                Name= formField.Name,
                PhoneNumber= formField.PhoneNumber,
                BirthDate= formField.BirthDate,
                Email= formField.Email,
                HomeAddress= formField.HomeAddress,
                ReferredToUs = formField.ReferredToUs,
                SelfiePhoto = selfiePath,
                Reference= formField.Reference,
                UploadFrontID =uploadFront,
                UploadBackID = uploadBack
            };
            await _unitOfWork.Repository.Add(field);
            await _unitOfWork.SaveAsync();
            return field;
        }
        

        public IEnumerable<FormField> GetAllDetails()
        {
            var results = _unitOfWork.Repository.ReadAllQuery().ToList();
            for (int i = 0; i < results.Count() - 1; i++)
            {
                results[i].SelfiePhoto = $"{_webHostEnvironment.WebRootPath}/{results[i].SelfiePhoto}";
                results[i].UploadFrontID = $"{_webHostEnvironment.WebRootPath}/{results[i].UploadFrontID}";
                results[i].UploadBackID = $"{_webHostEnvironment.WebRootPath}/{results[i].UploadBackID}";

            }
            return results.AsEnumerable();
        }
    }
}
