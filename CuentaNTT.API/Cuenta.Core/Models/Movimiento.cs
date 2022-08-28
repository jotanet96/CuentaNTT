using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaNTT.Core.Models {
    /***
     * •	Movimientos debe manejar una entidad  
     * •	Un movimiento tiene: Fecha, tipo movimiento, valor, saldo 
     * •	Debe manejar su Clave única 
     */
    public class Movimiento : BaseEntity<int> {
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }

        //Hereda
        [ForeignKey("CuentaId")]
        public string CuentaId { get; set; }
        public virtual Cuenta Cuenta { get; set; }
    }
}
