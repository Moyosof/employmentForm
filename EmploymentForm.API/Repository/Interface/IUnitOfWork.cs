namespace EmploymentForm.API.Repository.Interface
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Repository { get; }

        Task<bool> SaveAsync();

    }
}
