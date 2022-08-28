using CuentaNTT.Core.Models;

namespace CuentaNTT.Business.Interfaces {
    public interface IPersonaService {
        public Task<IEnumerable<Persona>> GetPersonasAsync();
        public Task<Persona> GetPersonaByIdAsync(int id);
        public Task<Persona> GetPersonaByIdentificacionAsync(string identificacion);
        public Task<Persona> AddPersonaAsync(Persona persona);
        public Task<bool> UpdatePersonaAsync(Persona persona);
        public Task<bool> DeletePersonaAsync(int id);
        public Task<bool> DeletePersonaByIdentificacionAsync(string identificacion);
    }
}
