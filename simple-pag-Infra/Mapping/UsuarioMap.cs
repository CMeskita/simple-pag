using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using simple_pag_Domain.Entity;


namespace simple_pag_Infra.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(usuario => usuario.Id)
              .HasColumnName("Id")
              .HasColumnType("varchar")
              .HasMaxLength(40)
              .IsRequired();

            builder.Property(usuario => usuario.Nome)
               .HasColumnName("Nome")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(usuario => usuario.Email)
               .HasColumnName("Email")
               .HasColumnType("varchar")
               .HasMaxLength(14)
               .IsRequired();

            builder.Property(usuario => usuario.ChavePrivada)
              .HasColumnName("ChavePrivada")
              .HasColumnType("varchar")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(usuario => usuario.Registro)
               .HasColumnName("Registro")
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
