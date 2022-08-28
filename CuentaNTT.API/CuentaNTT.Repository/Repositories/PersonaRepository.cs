using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Repository.Data;
using CuentaNTT.Core.Models;
using CuentaNTT.Infraestructure.Exceptions;

namespace CuentaNTT.Repository.Repositories {
    public class PersonaRepository : IPersonaRepository {
        private readonly CuentaNTTDBContext _db;
        private readonly DbSet<Persona> _entities;

        public PersonaRepository(CuentaNTTDBContext db) {
            _db = db;
            _entities = db.Set<Persona>();
        }

        public async Task<Persona> GetByIdentificacionsAsync(string identificacion) {
            Persona? _cliente = await _entities.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();

            if (_cliente == null) throw new NotFoundException(Constants.NOTFOUND);

            return _cliente;
        }

        public async Task<bool> DeletePersonaByIdentificacionAsync(string identificacion) {
            Persona? _persona = await _entities.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();

            _entities.Remove(_persona);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
