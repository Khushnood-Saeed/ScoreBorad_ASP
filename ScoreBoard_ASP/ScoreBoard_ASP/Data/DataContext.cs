using Microsoft.EntityFrameworkCore;
using ScoreBoard_ASP.Entities;

namespace ScoreBoard_ASP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

    }
}
