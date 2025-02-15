using AnimeList.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeList.Infrastructure.EntityConfigurations;

public class AnimeEntityConfiguration : IEntityTypeConfiguration<AnimeModel>
{
    public void Configure(EntityTypeBuilder<AnimeModel> builder)
    {
        builder.ToTable("Tb_Animes");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).ValueGeneratedOnAdd();
        builder.Property(s => s.Nome).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Diretor).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Resumo).IsRequired().HasMaxLength(500);
    }
}
