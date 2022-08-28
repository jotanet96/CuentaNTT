namespace CuentaNTT.Core.DTOs {
    public class CuentaDTO {
        public int Id { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }

        //Hereda
        public int PersonaId { get; set; }
    }
}
