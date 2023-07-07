using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmploymentFormWeb.Models
{
    public class FormDto
    {
        public Guid Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyy}")]
        public string BirthDate { get; set;}

        [DisplayName("Email Address")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Home Address")]
        public string HomeAddress { get; set; }

        [DisplayName("How were you referred to us?")]
        public string ReferredToUs { get; set; }

        [DisplayName("Selfie Photo")]
        public IFormFile SelfiePhoto { get; set; }

        [DisplayName("Reference")]
        public string Reference { get; set; }

        [DisplayName("Upload Front ID ")]
        public IFormFile UploadFrontID { get; set; }

        [DisplayName("Upload Back ID ")]
        public IFormFile UploadBackID { get; set; }
    }
}
