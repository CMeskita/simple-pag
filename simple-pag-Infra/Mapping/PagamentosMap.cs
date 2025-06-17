using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using simple_pag_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_pag_Infra.Mapping
{
    internal class PagamentosMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.Property(pagamenot => pagamenot.Id)
              .HasColumnName("Id")
              .HasColumnType("varchar")
              .HasMaxLength(40)
              .IsRequired();

            builder.Property(pagamenot => pagamenot.Nome)
               .HasColumnName("Nome")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(pagamenot => pagamenot.CodFinalizadora)
               .HasColumnName("CodFinalizadora")
               .HasColumnType("int")
               .HasMaxLength(14)
               .IsRequired();

            builder.Property(pagamenot => pagamenot.Registro)
              .HasColumnName("Registro")
              .HasColumnType("varchar")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(pagamenot => pagamenot.Sigla)
               .HasColumnName("Sigla")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();

            builder.Property(pagamenot => pagamenot.Status)
                .HasColumnName("Status")
                .HasColumnType("bool")
                .IsRequired();

            builder.HasKey(pagamenot => pagamenot.Id);

            builder.Ignore(x => x.Notification);
        }
    }
}
