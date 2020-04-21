using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    public class DetPedidoMapping : IEntityTypeConfiguration<DetPedido>
    {

        public void Configure(EntityTypeBuilder<DetPedido> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.ValorProduto).HasColumnType("decimal(18, 2)");
            builder.Property(e => e.ValorTotalProduto).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.CabPedido)
                .WithMany(p => p.DetPedido)
                .HasForeignKey(d => d.CabPedidoId);

            builder.HasOne(d => d.Produto)
                .WithMany(p => p.DetPedido)
                .HasForeignKey(d => d.ProdutoId);


            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");
            builder.ToTable("DetPedidos");
        }
    }
}

