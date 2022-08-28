using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Models;

namespace CuentaNTT.Repository.Data.Configurations {
    public class ClienteConfigurations : IEntityTypeConfiguration<Cliente> {

        void IEntityTypeConfiguration<Cliente>.Configure(EntityTypeBuilder<Cliente> builder) {

            builder.ToTable("clienteNTT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .IsRequired()
                   .HasColumnName("cli_id")
                   .HasColumnType("int");

            builder.Property(x => x.ClienteID)
                   .IsRequired()
                   .HasColumnName("cli_usuario")
                   .HasColumnType("varchar")
                   .HasMaxLength(16);

            builder.Property(x => x.Contrasena)
                   .IsRequired()
                   .HasColumnName("cli_contrasena")
                   .HasColumnType("varchar")
                   .HasMaxLength(500);

            builder.Property(x => x.Salt)
                   .IsRequired()
                   .HasColumnName("cli_salt")
                   .HasColumnType("varchar")
                   .HasMaxLength(500);

            builder.Property(x => x.PersonaId)
                   .IsRequired()
                   .HasColumnName("cli_personaId")
                   .HasColumnType("int");


            builder.Property(x => x.Estado)
                   .IsRequired()
                   .HasColumnName("cli_estado")
                   .HasColumnType("bit")
                   .HasDefaultValue(1);
        }
    }
}
