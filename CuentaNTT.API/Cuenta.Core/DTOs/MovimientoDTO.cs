namespace CuentaNTT.Core.DTOs {
    public class MovimientoDTO {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public double Valor { get; set; }
    }
}
