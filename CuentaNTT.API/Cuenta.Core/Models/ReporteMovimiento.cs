using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaNTT.Core.Models {
    public class ReporteMovimiento {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public double Movimiento { get; set; }
        public double SaldoDisponible { get; set; }
    }
}
