using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgGame.Models;

namespace RpgGame.Data.Maps
{
    public class PartidaLogMap : IEntityTypeConfiguration<PartidaLog>
    {
        public void Configure(EntityTypeBuilder<PartidaLog> builder)
        {
            builder.Property(partidaLog => partidaLog.Turno)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(partidaLog => partidaLog.DadoResultado)
                .IsRequired();

            builder.Property(partidaLog => partidaLog.Resultado)
                .IsRequired();

            builder.Property(partidaLog => partidaLog.Atributo)
                .IsRequired();

            builder.Property(partidaLog => partidaLog.Agilidade)
                .IsRequired();

            builder.Property(partidaLog => partidaLog.Defendeu)
                .IsRequired();

            builder.Property(partidaLog => partidaLog.DanoDadoResultado)
                .IsRequired(false);

            builder.Property(partidaLog => partidaLog.Dano)
           .IsRequired(false);

            builder.Property(partidaLog => partidaLog.DanoTotal)
            .IsRequired();

            builder.HasOne(partidaLog => partidaLog.Partida)
                .WithMany(partida => partida.Logs)
                .HasForeignKey(partidaLog => partidaLog.PartidaId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(partidaLog => partidaLog.Jogador)
                  .WithMany(partidaJogador => partidaJogador.Logs)
                  .HasForeignKey(partidaLog => partidaLog.PartidaJogadorId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .IsRequired();
        }
    }
}
