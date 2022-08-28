using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaNTT.Core.Models {
    public static class Constants {

        public const string NOTFOUND = @"No se encontró registro";
        public const string MULTIPLENOTFOUND = @"No se encontraron registros";
        public const string NEGATIVEBALANCE = @"El saldo no puede ser negativo";
        public const string NONAVAILABLEBALANCE = @"Saldo no disponible";
        public const string CLIENTEXISTS = @"El cliente ya está registrado";
        public const string CLIENTNOTEXISTS = @"El cliente no existe";
    }
}
