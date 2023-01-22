using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions<SocialDbContext> opt) : base(opt) 
        {

        }

        public DbSet<Post> Posts { get; set; }

    }
}
