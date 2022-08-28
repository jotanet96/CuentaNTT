using CuentaNTT.Core.Models;

namespace CuentaNTT.Business.Interfaces {
    public interface IReporteService {
        public Task<IEnumerable<ReporteMovimiento>> GetMovimientosByFechaAsync(string identificacion, DateTime fechaInicio, DateTime fechaFin);
    }
}
