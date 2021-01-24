using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Model;
using System;

namespace Banco.ConfigurationDB
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("film");

            builder
                .Property(f => f.Id)
                .HasColumnName("film_id");

            builder
                .Property(f => f.Titulo)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(f => f.Descricao)
                .HasColumnName("description")
                .HasColumnType("text");

            builder
                .Property(f => f.AnoLancamento)
                .HasColumnName("release_year")
                .HasColumnType("varchar(4)");

            builder
                .Property(f => f.IdIdiomaDublagem)
                .HasColumnName("language_id");

            builder
                .Property(f => f.IdIdiomaOriginal)
                .HasColumnName("original_language_id");

            builder
                .Property(f => f.DuracaoEmMinutos)
                .HasColumnName("length");

            builder
                .Property(f => f.Classificacao)
                .HasColumnName("rating")
                .HasColumnType("varchar(10)");

            builder
                .Property(f => f.ImagemCapa)
                .HasColumnName("cover_image")
                .HasColumnType("varbinary(max)");

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
