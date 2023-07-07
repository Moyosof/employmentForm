using EmploymentForm.API.Core;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EmploymentForm.API.ReadOnly
{
    public class FormFieldDto
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }


        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }


        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("HomeAddress")]
        public string HomeAddress { get; set; }

        [JsonProperty("ReferredToUs")]
        public string ReferredToUs { get; set; }

        public IFormFile SelfiePhoto { get; set; }

        public string Reference { get; set; }

        [Required]
        public IFormFile UploadFrontID { get; set; }

        [Required]
        public IFormFile UploadBackID { get; set; }
        public FormFieldDto(FormField formField)
        {
            Id = formField.Id;
            Name = formField.Name;
            PhoneNumber = formField.PhoneNumber;
            BirthDate = formField.BirthDate;
            Email = formField.Email;
            HomeAddress = formField.HomeAddress;
            ReferredToUs = formField.ReferredToUs;
            SelfiePhoto = SelfiePhoto;
            Reference = formField.Reference;
            UploadFrontID = UploadFrontID;
            UploadBackID = UploadBackID;
        }
    }
}
