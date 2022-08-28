using CuentaNTT.Core.Models;

namespace CuentaNTT.Core.Interfaces {
    public interface ICuentaRepository {
        public Task<Cuenta> GetCuentaByNumeroCuentaAsync(string numeroCuenta);
        public Task<IEnumerable<Cuenta>> GetCuentasByClientIdAsync(int clientId);

    }
}
