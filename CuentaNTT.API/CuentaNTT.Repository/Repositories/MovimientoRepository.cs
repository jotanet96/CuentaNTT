using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Repository.Data;
using CuentaNTT.Core.Models;

namespace CuentaNTT.Repository.Repositories {
    public class MovimientoRepository : IMovimientoRepository {
        private readonly CuentaNTTDBContext _db;
        private readonly DbSet<Movimiento> _entities;

        public MovimientoRepository (CuentaNTTDBContext db) {
            _db = db;
            _entities = db.Set<Movimiento>();
        }

        public async Task<IEnumerable<Movimiento>> GetMovimientosByNumeroCuentaAsync(string numeroCuenta) {
            var listOfMovimientos = await _entities.ToListAsync();
            var movimientos = listOfMovimientos.Where(x => x.CuentaId == numeroCuenta).ToList();
            return (IEnumerable<Movimiento>)movimientos;
        }

        public Task<IEnumerable<ReporteMovimiento>> GetMovimientosByFechaAsync(DateTime fechaInicio, DateTime fechaFin) {
            /*
             * Movimiento - Fecha
             * Persona - Nombre
             * Cuenta/Movimiento - Numero Cuenta
             * Cuenta - TipCuenta/Tipo
             * Cuenta - SaldoInicial
             * Cuenta - Estado
             * Movimiento - (Total Valor) byCuenta
             * Movimiento - Saldo Disponible
             */
            /*
            var listOfMovimientos = await _entities.ToListAsync();
            var movimientos = listOfMovimientos.Where(x => x.Fecha == numeroCuenta).ToList();
            return (IEnumerable<Movimiento>)movimientos;
            */
            return null;
        }
    }
}
