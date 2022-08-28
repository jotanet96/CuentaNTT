using CuentaNTT.Core.Models;

namespace CuentaNTT.Core.Interfaces {
    public interface IMovimientoRepository {
        public Task<IEnumerable<Movimiento>> GetMovimientosByNumeroCuentaAsync(string numeroCuenta);
    }
}
