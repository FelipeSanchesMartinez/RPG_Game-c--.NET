using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgGame.Models;

namespace RpgGame.Data.Maps
{
    public class PartidaJogadorMap : IEntityTypeConfiguration<PartidaJogador>
    {
        public void Configure(EntityTypeBuilder<PartidaJogador> builder)
        {
            builder.Property(partidaJogador => partidaJogador.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(partidaJogador => partidaJogador.Vida)
             .IsRequired();

            builder.Property(partidaJogador => partidaJogador.PrimeiroTurno)
                .IsRequired();

            builder.Property(partidaJogador => partidaJogador.ResultadoDadoPrimeiroTurno)
                .IsRequired();

            builder.HasOne(partidaJogador => partidaJogador.Personagem)
                .WithMany(personagem => personagem.PartidasJogador)
                .HasForeignKey(partidaJogador => partidaJogador.PersonagemId)
                .IsRequired();

        }
    }
}
