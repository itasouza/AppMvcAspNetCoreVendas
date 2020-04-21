using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    public class CabPedidoMapping : IEntityTypeConfiguration<CabPedido>
    {
        public void Configure(EntityTypeBuilder<CabPedido> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Observacoes).HasColumnType("text");
            builder.Property(e => e.Ativo).HasMaxLength(1).IsUnicode(false);
            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
            builder.Property(e => e.DataAlteracao).HasColumnType("datetime");
            builder.ToTable("CabPedidos");
        }

    }
}
