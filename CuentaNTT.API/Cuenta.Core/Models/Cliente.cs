using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaNTT.Core.Models {
    /**
     * •	Cliente debe manejar una entidad, que herede de la clase persona. 
     * •	Un cliente tiene:  clienteid, contraseña, estado. 
     * •	El cliente debe tener una clave única. (PK) 
     */
    public class Cliente : BaseEntity<int> {
        public Cliente() {
            this.Cuentas = new HashSet<Cuenta>();
        }

        public string ClienteID { get; set; }//Usuario
        public string Contrasena { get; set; }
        public string Salt { get; set; }
        public bool Estado { get; set; }

        //Hereda
        [ForeignKey("PersonaId")]
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        //Hijo
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
