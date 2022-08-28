using CuentaNTT.Core.Models;

namespace CuentaNTT.Core.Interfaces {
    public interface IClienteRepository {
        public Task<Cliente> GetByUsername(string username);

        }
    }
