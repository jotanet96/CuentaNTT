using CuentaNTT.Business.Helper;
using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Core.Models;
using CuentaNTT.Core.Exceptions;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CuentaNTT.Business.Services {
    public class ClienteService : IClienteService {

        private CuentaService _cuentaService;
        private ILogger<ClienteService> _logger;
        private readonly IClienteRepository _clienteRepository;
        private readonly IBaseRepository<Cliente, int> _baseRepository;

        public ClienteService(IBaseRepository<Cliente, int> baseRepository, ICuentaRepository cuentaRepository, ILogger<ClienteService> logger, ILogger<CuentaService> loggerCuenta, IClienteRepository clienteRepository) {
            _logger = logger;
            _baseRepository = baseRepository;
            _clienteRepository = clienteRepository;
            _cuentaService = new CuentaService(cuentaRepository, loggerCuenta);
        }

        public ClienteService(IClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;
        }
        public async Task<IEnumerable<Cliente>> GetClientesAsync() {
            _logger.LogInformation($"[ClienteService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");

            IEnumerable<Cliente> clientes = await _baseRepository.GetAllAsync();

            _logger.LogInformation($"[ClienteService] Fin de método: {MethodBase.GetCurrentMethod().Name}");

            return clientes;
        }


        public async Task<Cliente> GetClienteByIdAsync(int id) {
            Cliente cliente = await _baseRepository.GetByIdAsync(id);

            return cliente;
        }


        public async Task<Cliente> GetClienteByPersonaIdAsync(int idPersona) {
            Cliente cliente = await _clienteRepository.GetClienteByPersonaIdAsync(idPersona);

            return cliente;
        }


        public async Task<Cliente> GetClienteByUsername(string username) {

            Cliente cliente = await _clienteRepository.GetByUsername(username);

            return cliente;
        }

        public async Task<Cliente> AddClienteAsync(Cliente cliente) {

            HashedPassword hashedPassword;
            var lst = await _baseRepository.GetAllAsync();

            foreach (var item in lst) {
                if (item.ClienteID.Equals(cliente.ClienteID, StringComparison.InvariantCultureIgnoreCase) && item.Estado == true) {
                    
                    throw new BusinessException(Constants.CLIENTEXISTS);
                
                } else if (item.ClienteID.Equals(cliente.ClienteID, StringComparison.InvariantCultureIgnoreCase) && item.Estado == false) {
                    
                    hashedPassword = HashHelper.Hash(cliente.Contrasena);
                    cliente.Contrasena = hashedPassword.Password;
                    cliente.Salt = hashedPassword.Salt;

                    await _baseRepository.UpdateAsync(cliente);
                    return cliente;
            
                }
            }

            hashedPassword = HashHelper.Hash(cliente.Contrasena);
            cliente.Contrasena = hashedPassword.Password;
            cliente.Salt = hashedPassword.Salt;

            var clienteNuevo = await _baseRepository.AddAsync(cliente);
            
            return clienteNuevo;
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente) {
            
            Cliente _cliente = await _baseRepository.GetByIdAsync(cliente.Id);
            
            if (!_cliente.Estado) throw new BusinessException(Constants.NOTFOUND);
            
            cliente.Contrasena = _cliente.Contrasena;
            cliente.Salt = _cliente.Salt;
            
            var clienteActualizado = await _baseRepository.UpdateAsync(cliente);
                        
            return clienteActualizado;
        }

        public async Task<bool> DeleteClienteAsync(int id) {
            
            Cliente _cliente = await _baseRepository.GetByIdAsync(id);

            if (!_cliente.Estado) {
                throw new BusinessException(Constants.NOTFOUND);
            } else {
                IEnumerable<Cuenta> _cuentas = await _cuentaService.GetCuentasByClientIdAsync(id);
                if (_cuentas.Any()) {
                    foreach (var cuenta in _cuentas) {
                        await _cuentaService.DeleteCuentaAsync(cuenta.Id);
                    }
                }
            }
            
            _cliente.Estado = false;

            var cuentaEliminado = await _baseRepository.UpdateAsync(_cliente);
                        
            return cuentaEliminado;
        }
    }
}
