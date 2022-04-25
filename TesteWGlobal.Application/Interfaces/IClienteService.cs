using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteWGlobal.Application.Dtos;

namespace TesteWGlobal.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDto> Add(ClienteDto cliente);
        Task<ClienteDto> Update(int id, ClienteDto cliente);
        Task<bool> Delete(int id);
        Task<ClienteDto> GetById(int id);
        Task<IEnumerable<ClienteDto>> GetAll();
        Task<ClienteDto> GetByCpf(string cpf);
    }
}
