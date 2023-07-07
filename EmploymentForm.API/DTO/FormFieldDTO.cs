using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmploymentForm.API.DTO
{
    public class FormFieldDTO
    {
        [Required]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("PhoneNumber")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }

        [Required]
        [JsonProperty("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [JsonProperty("HomeAddress")]
        public string HomeAddress { get; set; }

        [Required]
        [JsonProperty("ReferredToUs")]
        public string ReferredToUs { get; set; }

        [Required]
        public IFormFile SelfiePhoto { get; set; }

        public string Reference { get; set; }

        [Required]
        public IFormFile UploadFrontID { get; set; }

        [Required]
        public IFormFile UploadBackID { get; set; }
    }
}
