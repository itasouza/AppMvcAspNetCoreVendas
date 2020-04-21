using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Logradouro).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Numero).IsRequired().HasColumnType("varchar(50)");
            builder.Property(p => p.Cep).IsRequired().HasColumnType("varchar(8)");
            builder.Property(p => p.Complemento).HasColumnType("varchar(250)");
            builder.Property(p => p.Bairro).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Cidade).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Estado).IsRequired().HasColumnType("varchar(50)");


            builder.HasOne(d => d.Cliente)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.ClienteId);

            builder.HasOne(d => d.Fornecedor)
                .WithMany(p => p.Enderecos)
                .HasForeignKey(d => d.FornecedorId);


            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");
            builder.ToTable("Enderecos");
        }

    }
}
