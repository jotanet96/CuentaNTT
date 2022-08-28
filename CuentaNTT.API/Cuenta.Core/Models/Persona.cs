using System.ComponentModel.DataAnnotations.Schema;

namespace CuentaNTT.Core.Models {

    public class Persona : BaseEntity<int> {

        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        //Hereda
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
