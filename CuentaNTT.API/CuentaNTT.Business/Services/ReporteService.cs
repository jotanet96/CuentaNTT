using CuentaNTT.Business.Interfaces;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Core.Models;
using CuentaNTT.Core.Exceptions;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CuentaNTT.Business.Services {
    public class ReporteService : IReporteService {

        private ILogger<ReporteService> _logger;
        private PersonaService _personaService;
        private ClienteService _clienteService;
        private CuentaService _cuentaService;
        private MovimientoService _movimientoService;


        public ReporteService(IPersonaRepository personaRepository, IClienteRepository clienteRepository, ICuentaRepository cuentaRepository, 
                IMovimientoRepository movimientoRepository,
                ILogger<ReporteService> logger, ILogger<PersonaService> loggerPersona, ILogger<CuentaService> loggerCuenta, ILogger<ClienteService> loggerCliente,
                ILogger<MovimientoService> loggerMovimiento) {
            _logger = logger;
            _personaService = new PersonaService(personaRepository, loggerPersona);
            _clienteService = new ClienteService(clienteRepository);
            _cuentaService = new CuentaService(cuentaRepository, loggerCuenta);
            _movimientoService = new MovimientoService(movimientoRepository, loggerMovimiento);
        }

        public async Task<IEnumerable<ReporteMovimiento>> GetMovimientosByFechaAsync(string identificacion, DateTime fechaInicio, DateTime fechaFin) {
            _logger.LogInformation($"[ReporteService] Inicio de método: {MethodBase.GetCurrentMethod().Name}");
            
            double saldo = 0.0;
            double transacciones = 0.0;

            List<ReporteMovimiento> _reporteMovimientos = new List<ReporteMovimiento>();

            Persona? persona = await _personaService.GetPersonaByIdentificacionAsync(identificacion);
            if (persona == null) throw new BusinessException(Constants.NONPERSON);
            Cliente? cliente = await _clienteService.GetClienteByPersonaIdAsync(persona.Id);
            if (cliente == null) throw new BusinessException(Constants.NONCLIENT);
            IEnumerable<Cuenta>? cuentas = await _cuentaService.GetCuentasByClientIdAsync(cliente.Id);

            if (cuentas.Any()) {
                foreach (Cuenta cuenta in cuentas) {
                    IEnumerable<Movimiento>? movimientos = await _movimientoService.GetMovimientosByNumeroCuentaAsync(cuenta.NumeroCuenta);
                    IEnumerable<Movimiento>? _movimientos = movimientos.Where(x => x.Fecha >= fechaInicio && x.Fecha <= fechaFin).ToList();

                    transacciones = 0.0;
                    if (movimientos.Any()) {
                        foreach (Movimiento movimiento in _movimientos) {
                            transacciones += movimiento.Valor;
                            saldo = movimiento.Saldo;//Se toma el ultimo saldo registrado en base
                        }

                        ReporteMovimiento reporte = new();
                        reporte.Fecha = DateTime.Now;
                        reporte.Cliente = persona.Nombre;
                        reporte.NumeroCuenta = cuenta.NumeroCuenta;
                        reporte.TipoCuenta = cuenta.TipoCuenta;
                        reporte.SaldoInicial = cuenta.SaldoInicial;
                        reporte.Estado = cuenta.Estado;
                        reporte.Movimiento = transacciones;
                        reporte.SaldoDisponible = saldo;

                        _reporteMovimientos.Add(reporte);

                    } else {

                        ReporteMovimiento reporte = new();
                        reporte.Fecha = DateTime.Now;
                        reporte.Cliente = persona.Nombre;
                        reporte.NumeroCuenta = cuenta.NumeroCuenta;
                        reporte.TipoCuenta = cuenta.TipoCuenta;
                        reporte.SaldoInicial = cuenta.SaldoInicial;
                        reporte.Estado = cuenta.Estado;
                        reporte.Movimiento = transacciones;
                        reporte.SaldoDisponible = cuenta.SaldoInicial;//Si no registra movimiento se toma el saldo inicial como saldo disponible

                        _reporteMovimientos.Add(reporte);

                    }
                }
            } else {
                throw new BusinessException(Constants.NONACCOUNT);
            }
            _logger.LogInformation($"[ReporteService] Fin de método: {MethodBase.GetCurrentMethod().Name}");


            IEnumerable<ReporteMovimiento> reporteMovimientos = _reporteMovimientos.ToList();
            return reporteMovimientos;
        }

    }
}
