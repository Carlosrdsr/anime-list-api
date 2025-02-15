using AnimeList.Domain.Model;
using AnimeList.Infrastructure.EntityConfigurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AnimeList.Infrastructure.Data
{
    public class AnimeDbContext : DbContext
    {
        public DbSet<AnimeModel> Animes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AnimeEntityConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=DESKTOP-IL6MI7E;Database=desafiodb;Integrated Security=SSPI;TrustServerCertificate=True");

        private readonly string? _connectionString;

        public AnimeDbContext(DbContextOptions<AnimeDbContext> options) : base(options)
        {
            _connectionString = "Server=DESKTOP-IL6MI7E;Database=desafiodb;Integrated Security=SSPI;TrustServerCertificate=True";
        }

        public IDbConnection CreateDbConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IDbConnection GetCurrentConnection()
        {
            return Database.GetDbConnection();
        }
    }
}
