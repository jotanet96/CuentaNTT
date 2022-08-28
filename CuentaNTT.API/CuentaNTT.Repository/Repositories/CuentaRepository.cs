using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Repository.Data;
using CuentaNTT.Core.Models;
using CuentaNTT.Infraestructure.Exceptions;

namespace CuentaNTT.Repository.Repositories {
    public class CuentaRepository : ICuentaRepository {
        private readonly CuentaNTTDBContext _db;
        private readonly DbSet<Cuenta> _entities;

        public CuentaRepository(CuentaNTTDBContext db) {
            _db = db;
            _entities = db.Set<Cuenta>();
        }

        public async Task<Cuenta> GetCuentaByNumeroCuentaAsync(string numeroCuenta) {
            Cuenta? _cuenta = await _entities.Where(x => x.NumeroCuenta == numeroCuenta && x.Estado == true).FirstOrDefaultAsync();

            if (_cuenta == null) throw new NotFoundException(Constants.NOTFOUND);

            return _cuenta;
        }

        public async Task<IEnumerable<Cuenta>> GetCuentasByClientIdAsync(int clientId) {
            IEnumerable<Cuenta>? _cuentas = await _entities.Where(x => x.ClienteId == clientId && x.Estado == true).ToListAsync();

            if (!_cuentas.Any()) throw new NotFoundException(Constants.MULTIPLENOTFOUND);

            return _cuentas;
        }
    }
}
