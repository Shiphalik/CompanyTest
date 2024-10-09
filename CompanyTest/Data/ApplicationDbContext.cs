using CompanyTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyTest
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<STUDENT> STUDENT { get; set; }
        public DbSet<TEACHER> TEACHER { get; set; }
        public DbSet<SUBJECTS> SUBJECTS { get; set; }
        
    }
}
