using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.Exceptions;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Core.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CuentaNTT.Business.Services {
    public class CuentaService : ICuentaService {

        private ILogger<CuentaService> _logger;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IBaseRepository<Cuenta, int> _baseRepository;

        public CuentaService(ICuentaRepository cuentaRepository, IBaseRepository<Cuenta, int> baseRepository, ILogger<CuentaService> logger) {
            _logger = logger;
            _baseRepository = baseRepository;
            _cuentaRepository = cuentaRepository;
        }

        public CuentaService(ICuentaRepository cuentaRepository, ILogger<CuentaService> logger) {
            _logger = logger;
            _cuentaRepository = cuentaRepository;
        }

        public async Task<IEnumerable<Cuenta>> GetCuentasAsync() {
            _logger.LogInformation($"[CuentaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            IEnumerable<Cuenta> cuenta = await _baseRepository.GetAllAsync();
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            return cuenta;
        }

        public async Task<IEnumerable<Cuenta>> GetCuentasByClientIdAsync(int clientId) {
            _logger.LogInformation($"[CuentaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            IEnumerable<Cuenta> cuenta = await _cuentaRepository.GetCuentasByClientIdAsync(clientId);
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            return cuenta;
        }

        public async Task<Cuenta> GetCuentaByNumeroCuentaAsync(string numeroCuenta) {
            _logger.LogInformation($"[CuentaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            Cuenta cuenta = await _cuentaRepository.GetCuentaByNumeroCuentaAsync(numeroCuenta);
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            return cuenta;
        }

        public async Task<Cuenta> GetCuentaByIdAsync(int id) {
            _logger.LogInformation($"[CuentaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            Cuenta cuenta = await _baseRepository.GetByIdAsync(id);
            if (!cuenta.Estado) throw new BusinessException(Constants.NOTFOUND);
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            return cuenta;
        }

        public async Task<Cuenta> AddCuentaAsync(Cuenta cuenta) {
            _logger.LogInformation($"[CuentaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            if (cuenta.SaldoInicial < 0) throw new BusinessException(Constants.NEGATIVEBALANCE);
            Cuenta cuentaNuevo = await _baseRepository.AddAsync(cuenta);
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            return cuentaNuevo;
        }

        public async Task<bool> UpdateCuentaAsync(Cuenta cuenta) {
            _logger.LogInformation($"[CuentaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            Cuenta _cuenta = await _cuentaRepository.GetCuentaByNumeroCuentaAsync(cuenta.NumeroCuenta);
            if (!_cuenta.Estado) throw new BusinessException(Constants.NOTFOUND);

            var cuentaActualizado = await _baseRepository.UpdateAsync(cuenta);
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            return cuentaActualizado;
        }

        public async Task<bool> DeleteCuentaAsync(int id) {
            _logger.LogInformation($"[CuentaService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            Cuenta _cuenta = await _baseRepository.GetByIdAsync(id);
            if (!_cuenta.Estado) throw new BusinessException(Constants.NOTFOUND);
            _cuenta.Estado = false;

            var cuentaEliminado = await _baseRepository.UpdateAsync(_cuenta);
            _logger.LogInformation($"[CuentaService] Fin de método: {MethodBase.GetCurrentMethod().Name}");
            return cuentaEliminado;
        }

    }
}
