using CuentaNTT.Core.Models;

namespace CuentaNTT.Core.Interfaces {
    public interface IPersonaRepository {
        public Task<Persona> GetByIdentificacionsAsync(string identificacion);
        public Task<bool> DeletePersonaByIdentificacionAsync(string identificacion);

        }
    }
