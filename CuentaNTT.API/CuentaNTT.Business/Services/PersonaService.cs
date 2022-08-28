using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Core.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CuentaNTT.Business.Services {
    public class PersonaService : IPersonaService {

        private ILogger<PersonaService> _logger;
        private readonly IPersonaRepository _personaRepository;
        private readonly IBaseRepository<Persona, int> _baseRepository;

        public PersonaService(IPersonaRepository personaRepository, IBaseRepository<Persona, int> baseRepository, ILogger<PersonaService> logger) {
            _logger = logger;
            _baseRepository = baseRepository;
            _personaRepository = personaRepository;
        }

        public async Task<IEnumerable<Persona>> GetPersonasAsync() {
            _logger.LogInformation($"[PersonaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            
            IEnumerable<Persona> persona = await _baseRepository.GetAllAsync();

            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");

            return persona;
        }

        public async Task<Persona> GetPersonaByIdAsync(int id) {
            _logger.LogInformation($"[PersonaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            
            Persona persona = await _baseRepository.GetByIdAsync(id);

            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");

            return persona;
        }

        public async Task<Persona> GetPersonaByIdentificacionAsync(string identificacion) {
            _logger.LogInformation($"[PersonaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            
            Persona persona = await _personaRepository.GetByIdentificacionsAsync(identificacion);

            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            
            return persona;
        }

        public async Task<Persona> AddPersonaAsync(Persona persona) {
            _logger.LogInformation($"[PersonaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

            Persona personaNuevo = await _baseRepository.AddAsync(persona);

            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");

            return personaNuevo;
        }

        public async Task<bool> UpdatePersonaAsync(Persona persona) {
            _logger.LogInformation($"[PersonaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

            await _baseRepository.GetByIdAsync(persona.Id);


            var personaActualizado = await _baseRepository.UpdateAsync(persona);
            
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");

            return personaActualizado;
        }

        public async Task<bool> DeletePersonaAsync(int id) {
            _logger.LogInformation($"[PersonaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

            await _baseRepository.GetByIdAsync(id);

            var personaEliminado = await _baseRepository.DeleteAsync(id);
            if (personaEliminado) {

            }

            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");

            return personaEliminado;
        }

        public async Task<bool> DeletePersonaByIdentificacionAsync(string identificacion) {
            _logger.LogInformation($"[PersonaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

            await _personaRepository.GetByIdentificacionsAsync(identificacion);

            var personaEliminado = await _personaRepository.DeletePersonaByIdentificacionAsync(identificacion);
            if (personaEliminado) {

            }

            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");

            return personaEliminado;
        }
        
    }
}
