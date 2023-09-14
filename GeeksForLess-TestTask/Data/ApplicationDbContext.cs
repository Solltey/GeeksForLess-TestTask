using GeeksForLess_TestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksForLess_TestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Catalog> Catalogs { get; set; } = default!;
    }
}
