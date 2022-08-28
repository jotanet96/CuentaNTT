namespace CuentaNTT.Core.DTOs {

    public class ClienteDTO {
        public int Id { get; set; }
        public string ClienteId { get; set; }//Usuario
        public string Contrasena { get; set; }

        //Hereda
        public int PersonaId { get; set; }
    }
}
