using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgGame.Models;

namespace RpgGame.Data.Maps
{
    public class PartidaMap : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.Property(partida => partida.Turno)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(partida => partida.Finalizado)
           .IsRequired();

            builder.HasOne(partida => partida.Jogador1)
                    .WithOne(partidaJogador => partidaJogador.Partida1)
                    .HasForeignKey<Partida>(partida => partida.PartidaJogador1Id)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

            builder.HasOne(partida => partida.Jogador2)
                    .WithOne(partidaJogador => partidaJogador.Partida2)
                    .HasForeignKey<Partida>(partida => partida.PartidaJogador2Id)
                    .OnDelete(DeleteBehavior.NoAction)
                    .IsRequired();

            builder.HasOne(partida => partida.JogadorTurno)
                     .WithOne(partidaJogador => partidaJogador.PartidaTurno)
                     .HasForeignKey<Partida>(partida => partida.PartidaJogadorTurnoId)
                     .OnDelete(DeleteBehavior.NoAction)
                     .IsRequired();

            builder.HasOne(partida => partida.JogadorVencedor)
                  .WithOne(partidaJogador => partidaJogador.PartidaVencedor)
                   .HasForeignKey<Partida>(partida => partida.PartidaJogadorVencedorId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
