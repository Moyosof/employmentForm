using EmploymentForm.API.Core;
using Microsoft.EntityFrameworkCore;

namespace EmploymentForm.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<FormField> FormFields { get; set; }
    }
}
