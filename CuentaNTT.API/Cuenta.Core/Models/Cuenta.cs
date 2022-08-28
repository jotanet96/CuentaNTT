using System.ComponentModel.DataAnnotations.Schema;

namespace CuentaNTT.Core.Models {
    /***
     * •	Cuenta debe manejar una entidad  
     * •	Una cuenta tiene: número cuenta, tipo cuenta, saldo Inicial, estado. 
     * •	Debe manejar su Clave única 
     */

    public class Cuenta : BaseEntity<int>{

        public Cuenta() {
            this.Movimientos = new HashSet<Movimiento>();
        }

        //PK
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }

        //Hereda
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        //Hijo
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
