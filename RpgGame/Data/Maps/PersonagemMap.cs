using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgGame.Models;

namespace RpgGame.Data.Maps
{
    public class PersonagemMap : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.Property(personagem => personagem.Nome)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(personagem => personagem.Tipo)
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(personagem => personagem.Vida)
                .IsRequired();

            builder.Property(personagem => personagem.Forca).
                IsRequired();

            builder.Property(personagem => personagem.Defesa)
                .IsRequired();

            builder.Property(personagem => personagem.Agilidade)
                .IsRequired();

            builder.Property(personagem => personagem.QtdDados)
                .IsRequired();

            builder.Property(personagem => personagem.FacesDado)
                .IsRequired();

        }
    }
}
