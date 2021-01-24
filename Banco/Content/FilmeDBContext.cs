using Banco.ConfigurationDB;
using Microsoft.EntityFrameworkCore;
using Negocio.Model;

namespace Banco.Content
{
    public class FilmeDBContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        public FilmeDBContext(DbContextOptions<FilmeDBContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=(localdb)\\mssqllocaldb;Database=AluraFilmes;Trusted_Connection=true;MultipleActiveResultSets=true";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
