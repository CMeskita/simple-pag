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
    internal class FinalizadoraMap : IEntityTypeConfiguration<Finalizadora>
    {
        public void Configure(EntityTypeBuilder<Finalizadora> builder)
        {
            builder.Property(finalizadora => finalizadora.Id)
               .HasColumnName("Id")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();

            builder.Property(finalizadora => finalizadora.Valor)
               .HasColumnName("Valor")
               .HasColumnType("deciamal")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(finalizadora => finalizadora.Registro)
                .HasColumnName("Registro")
                .HasColumnType("varchar")
                .IsRequired();

            builder.HasKey(finalizadora => finalizadora.Id);

            builder.Ignore(x => x.Notification);
        }
    }
}
