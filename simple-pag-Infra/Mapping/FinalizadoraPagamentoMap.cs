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
    public class FinalizadoraPagamentoMap : IEntityTypeConfiguration<FinalizadoraPagamento>
    {
        public void Configure(EntityTypeBuilder<FinalizadoraPagamento> builder)
        {
            builder.Property(finalizadora => finalizadora.Id)
              .HasColumnName("Id")
              .HasColumnType("varchar")
              .HasMaxLength(40)
              .IsRequired();

            builder.Property(finalizadora => finalizadora.FinalizadoraId)
               .HasColumnName("FinalizadoraId")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();

            builder.Property(finalizadora => finalizadora.Valor)
               .HasColumnName("Valor")
               .HasColumnType("deciamal")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(finalizadora => finalizadora.Parcelas)
                .HasColumnName("Parcelas")
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(finalizadora => finalizadora.Modalidade)
                .HasColumnName("Modalidade")
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(finalizadora => finalizadora.PagamentoId)
                .HasColumnName("PagamentoId")
                .HasColumnType("varchar")
                .IsRequired();
            builder.Property(finalizadora => finalizadora.Vencimento)
               .HasColumnName("Vencimento")
               .HasColumnType("varchar")
               .IsRequired();

            builder.HasKey(finalizadora => finalizadora.Id);
            builder.Ignore(x => x.Notification);
        }
    }
}
