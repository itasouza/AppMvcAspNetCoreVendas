using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Descricao).IsRequired().HasColumnType("varchar(1000)");
            builder.Property(p => p.Imagem).HasColumnType("varchar(100)");
            builder.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.DataValidade).HasColumnType("datetime");
            builder.Property(e => e.ProdutoPromocao).HasMaxLength(1).IsUnicode(false);


            builder.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.FornecedorId);

            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");
            builder.ToTable("Produtos");
        }

    }



}
