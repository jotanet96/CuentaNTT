using CuentaNTT.Core.Models;

namespace CuentaNTT.Business.Interfaces {
    public interface IClienteService {
        public Task<IEnumerable<Cliente>> GetClientesAsync();
        public Task<Cliente> GetClienteByIdAsync(int id);
        public Task<Cliente> GetClienteByUsername(string username);
        public Task<Cliente> AddClienteAsync(Cliente cliente);
        public Task<bool> UpdateClienteAsync(Cliente cliente);
        public Task<bool> DeleteClienteAsync(int id);
    }
}
