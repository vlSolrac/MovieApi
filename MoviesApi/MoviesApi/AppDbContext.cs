using Microsoft.EntityFrameworkCore;
using MoviesApi.Models;

namespace MoviesApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genre> genres { get; set; }

    }
}
