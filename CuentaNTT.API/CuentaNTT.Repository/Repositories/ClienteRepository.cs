using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Repository.Data;
using CuentaNTT.Core.Models;
using CuentaNTT.Infraestructure.Exceptions;

namespace CuentaNTT.Repository.Repositories {
    public class ClienteRepository : IClienteRepository {
        private readonly CuentaNTTDBContext _db;
        private readonly DbSet<Cliente> _entities;

        public ClienteRepository(CuentaNTTDBContext db) {
            _db = db;
            _entities = db.Set<Cliente>();
        }

        public async Task<Cliente> GetByUsername(string username) {
            var _usuario = await _entities.Where(x => x.ClienteID == username && x.Estado == true).FirstOrDefaultAsync();
            if (_usuario == null) throw new Exception(Constants.CLIENTNOTEXISTS);

            return _usuario;
        }

        public async Task<Cliente> GetClienteByPersonaIdAsync(int idPersona) {
            var _usuario = await _entities.Where(x => x.PersonaId == idPersona && x.Estado == true).FirstOrDefaultAsync();
            if (_usuario == null) throw new Exception(Constants.CLIENTNOTEXISTS);

            return _usuario;
        }
    }
}
