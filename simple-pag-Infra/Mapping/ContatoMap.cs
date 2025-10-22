using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using simple_pag_Domain.Entity;

namespace simple_pag_Infra.Mapping
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.Property(usuario => usuario.Id)
             .HasColumnName("Id")
             .HasColumnType("varchar")
             .HasMaxLength(40)
             .IsRequired();

            builder.Property(usuario => usuario.Descricao)
               .HasColumnName("Descricao")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(usuario => usuario.Conteudo)
               .HasColumnName("Conteudo")
               .HasColumnType("varchar")
               .HasMaxLength(14)
               .IsRequired();

            builder.Property(usuario => usuario.Registro)
              .HasColumnName("Registro")
              .HasColumnType("timestamptz")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(usuario => usuario.UsuarioId)
               .HasColumnName("UsuarioId")
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsRequired();

            builder.Property(usuario => usuario.Status)
                .HasColumnName("Status")
                .HasColumnType("bool")
                .IsRequired();

            builder.HasKey(usuario => usuario.Id);

            builder.Ignore(x => x.Notification);
        }
    }
}
