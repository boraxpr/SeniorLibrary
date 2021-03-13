using Microsoft.EntityFrameworkCore;

namespace SeniorLibrary.Data
{
    public class SeniorLibraryContext : DbContext
    {
        public SeniorLibraryContext (
            DbContextOptions<SeniorLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<SeniorLibrary.Models.Entrying> Entrying { get; set; }
    }
}