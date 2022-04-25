using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteWGlobal.Domain.Models;

namespace TesteWGlobal.Repository.Interfaces
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        Task<bool> SaveChangesAsync();
        Task<Cliente> GetByIdAsync(int Id);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByCpf(string cpf);
    }
}
