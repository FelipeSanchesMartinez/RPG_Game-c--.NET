using Microsoft.EntityFrameworkCore;
using RpgGame.Data.Maps;
using RpgGame.Models;

namespace RpgGame.Data
{
    public class SQLContext : DbContext
    {
        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<PartidaJogador> PartidaJogador { get; set; }
        public DbSet<PartidaLog> PartidaLog { get; set; }

        private readonly IConfiguration _configuration;

        public SQLContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonagemMap());
            modelBuilder.ApplyConfiguration(new PartidaMap());
            modelBuilder.ApplyConfiguration(new PartidaJogadorMap());
            modelBuilder.ApplyConfiguration(new PartidaLogMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("SQLServer");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
