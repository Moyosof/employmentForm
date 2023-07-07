using EmploymentForm.API.ReadOnly;

namespace EmploymentForm.API.Core
{
    public class FormField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string ReferredToUs { get; set; }
        public string SelfiePhoto { get; set; }
        public string Reference { get; set; }
        public string UploadFrontID { get; set; }
        public string UploadBackID { get; set;}

        public FormField(FormFieldDto formField)
        {
            Id = Guid.NewGuid();
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

        public FormField()
        {
        }
    }
}
