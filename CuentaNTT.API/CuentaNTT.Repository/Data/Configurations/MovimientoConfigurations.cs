using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Models;

namespace CuentaNTT.Repository.Data.Configurations {
    public class MovimientoConfigurations : IEntityTypeConfiguration<Movimiento> {

        void IEntityTypeConfiguration<Movimiento>.Configure(EntityTypeBuilder<Movimiento> builder) {

            builder.ToTable("movimientoNTT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .IsRequired()
                   .HasColumnName("mov_id")
                   .HasColumnType("int");

            builder.Property(x => x.Fecha)
                   .IsRequired()
                   .HasColumnName("mov_usuario")
                   .HasColumnType("datetime");

            builder.Property(x => x.TipoMovimiento)
                   .IsRequired()
                   .HasColumnName("mov_tipo_movimiento")
                   .HasColumnType("varchar")
                   .HasMaxLength(16);

            builder.Property(x => x.Valor)
                   .IsRequired()
                   .HasColumnName("mov_valor")
                   .HasColumnType("decimal(15,3)");

            builder.Property(x => x.Saldo)
                   .IsRequired()
                   .HasColumnName("mov_saldo")
                   .HasColumnType("decimal(15,3)");

            builder.Property(x => x.CuentaId)
                   .IsRequired()
                   .HasColumnName("mov_cuentaId")
                   .HasColumnType("varchar")
                   .HasMaxLength(16);
        }
    }
}