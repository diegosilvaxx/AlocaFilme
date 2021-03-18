using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class LocacaoMapping : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.HasOne(x => x.Filme)
                .WithMany(x => x.Locacao)
                .HasForeignKey(e => e.IdFilme)
                .IsRequired(false);

            builder.ToTable("Locacoes");
        }
    }
}