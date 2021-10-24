using Domain.Security;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Login> Logins { get; set; }
    }
}
