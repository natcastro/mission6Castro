using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class MovieAppcContex : DbContext
    {
        public MovieAppcContex(DbContextOptions<MovieAppcContex> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}