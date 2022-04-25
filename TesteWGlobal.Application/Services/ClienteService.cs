using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteWGlobal.Application.Dtos;
using TesteWGlobal.Application.Helpers;
using TesteWGlobal.Application.Interfaces;
using TesteWGlobal.Domain.Models;
using TesteWGlobal.Repository.Interfaces;

namespace TesteWGlobal.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        private Validates validacao = new Validates();

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ClienteDto> Add(ClienteDto clienteDto)
        {
            try
            {
                var validar_cpf = await GetByCpf(clienteDto.Cpf);

                if (validar_cpf != null) throw new Exception("Erro ao adicionar. CPF ja existe na base.");

                if (!validacao.cpfCnpj(clienteDto.Cpf)) throw new Exception("Erro ao adicionar. CPF invalido.");

                var cliente = _mapper.Map<Cliente>(clienteDto);

                cliente.DataCadastro = DateTime.Now;

                _repository.Add(cliente);

                if (await _repository.SaveChangesAsync())
                    return _mapper.Map<ClienteDto>(await _repository.GetByIdAsync(cliente.Id));

                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<ClienteDto> Update(int id, ClienteDto cliente)
        {
            try
            {
                if (!validacao.cpfCnpj(cliente.Cpf)) throw new Exception("Erro ao atualizar. CPF invalido.");

                var cliente_base = await _repository.GetByIdAsync(id);

                if (cliente_base == null) return null;

                cliente.Id = cliente_base.Id;

                _mapper.Map(cliente, cliente_base);

                _repository.Update(cliente_base);

                if (await _repository.SaveChangesAsync())
                    return _mapper.Map<ClienteDto>(await _repository.GetByIdAsync(cliente.Id));

                return null;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var cliente = await _repository.GetByIdAsync(id);

                if (cliente == null) throw new Exception("Registro nao encontrado");

                _repository.Delete(cliente);

                return await _repository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            try
            {
                var results = await _repository.GetAllAsync();

                if (results == null) return null;

                var clientes = _mapper.Map<ClienteDto[]>(results);

                return clientes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ClienteDto> GetByCpf(string cpf)
        {
            try
            {
                var result = await _repository.GetByCpf(cpf);

                if (result == null) return null;

                var cliente = _mapper.Map<ClienteDto>(result);

                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ClienteDto> GetById(int id)
        {
            try
            {
                var result = await _repository.GetByIdAsync(id);

                if (result == null) return null;

                var cliente = _mapper.Map<ClienteDto>(result);

                return cliente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
