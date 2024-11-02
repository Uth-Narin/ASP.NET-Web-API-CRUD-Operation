using EmployeeAdminePortail.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminePortail.Data
{
    public class ApplicationDBContextcs : DbContext
    {
        public ApplicationDBContextcs(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee>Employees{ get; set; }
    }
}
