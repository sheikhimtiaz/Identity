using Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}