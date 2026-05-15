using Microsoft.EntityFrameworkCore;
using EmployeesManagement.Models;
namespace EmployeesManagement.Data;
public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) {}
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instrument> Instruments { get; set; }
    protected override void OnModelCreating(ModelBuilder b) {
        b.Entity<Employee>().Ignore(e => e.FullName);
    }
}
