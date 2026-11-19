using Microsoft.EntityFrameworkCore;

namespace Giyim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        
    }
}
