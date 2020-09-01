using Microsoft.EntityFrameworkCore;

namespace TestApp1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Person> Person { get; set; }
    }
}
