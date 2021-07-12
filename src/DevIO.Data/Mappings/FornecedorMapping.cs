using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
  public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
  {
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
      builder.HasKey(f => f.Id);

      builder.Property(f => f.Nome)
              .IsRequired()
              .HasColumnType("varchar(100)");

      builder.Property(f => f.Documento)
              .IsRequired()
              .HasColumnType("varchar(14)");

      // 1 : 1 Fornecedor : Endereco Relação EF
      builder.HasOne(f => f.Endereco)
              .WithOne(e => e.Fornecedor);

      // 1 : N Fornecedor : Produtos Relação EF
      builder.HasMany(f => f.Produtos)
            .WithOne(p => p.Fornecedor)
            .HasForeignKey(p => p.FornecedorID);

      builder.ToTable("Fornecedores");

    }
  } 
}
