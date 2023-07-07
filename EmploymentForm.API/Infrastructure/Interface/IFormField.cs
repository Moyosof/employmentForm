using EmploymentForm.API.Core;
using EmploymentForm.API.DTO;
using EmploymentForm.API.ReadOnly;

namespace EmploymentForm.API.Infrastructure.Interface
{
    public interface IFormField
    {
        //Task<List<FormField>> GetAllDetails(CancellationToken cancellation);
        IEnumerable<FormField> GetAllDetails();
        Task<FormField> AddEmploymentField(FormFieldDTO formField); 
    }
}
