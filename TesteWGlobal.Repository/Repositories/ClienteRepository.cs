using System;
using System.Collections.Generic;
using TesteWGlobal.Domain.Models;
using TesteWGlobal.Repository.Interfaces;
using TesteWGlobal.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace TesteWGlobal.Repository.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add(Cliente cliente)
        {
            _context.Add(cliente);
        }

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
        }

        public void Delete(Cliente cliente)
        {
            _context.Remove(cliente);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetByIdAsync(int Id)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.Where(s => s.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetByCpf(string cpf)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.Where(s => s.Cpf == cpf);

            return await query.FirstOrDefaultAsync();
        }
    }
}
