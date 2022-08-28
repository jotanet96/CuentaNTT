using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Models;

namespace CuentaNTT.Repository.Data.Configurations {
    public class PersonaConfigurations : IEntityTypeConfiguration<Persona> {

        void IEntityTypeConfiguration<Persona>.Configure(EntityTypeBuilder<Persona> builder) {

            builder.ToTable("personaNTT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .IsRequired()
                   .HasColumnName("per_id")
                   .HasColumnType("int");

            builder.Property(x => x.Identificacion)
                   .IsRequired()
                   .HasColumnName("per_identificacion")
                   .HasColumnType("varchar")
                   .HasMaxLength(16);

            builder.Property(x => x.Nombre)
                   .IsRequired()
                   .HasColumnName("per_nombre")
                   .HasColumnType("varchar")
                   .HasMaxLength(64);

            builder.Property(x => x.Genero)
                   .IsRequired()
                   .HasColumnName("per_genero")
                   .HasColumnType("varchar")
                   .HasMaxLength(10);

            builder.Property(x => x.Edad)
                   .IsRequired()
                   .HasColumnName("per_edad")
                   .HasColumnType("int");

            builder.Property(x => x.Direccion)
                   .IsRequired()
                   .HasColumnName("per_direccion")
                   .HasColumnType("varchar")
                   .HasMaxLength(128);

            builder.Property(x => x.Telefono)
                   .IsRequired(false)
                   .HasColumnName("per_telefono")
                   .HasColumnType("varchar")
                   .HasMaxLength(16);

            builder.Property(x => x.ClientId)
                   .IsRequired()
                   .HasColumnName("per_clientId")
                   .HasColumnType("int");
        }
    }
}
