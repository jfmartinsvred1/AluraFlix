using AluraFlixAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlixAPI.Data
{
    public class AluraFlixContext : DbContext
    {
        public AluraFlixContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
    }
}
