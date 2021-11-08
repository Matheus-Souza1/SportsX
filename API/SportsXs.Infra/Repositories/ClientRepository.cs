using Microsoft.EntityFrameworkCore;
using SportsXs.Domain.Entities;
using SportsXs.Domain.Repositories;
using SportsXs.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsXs.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly SportsXsContext _context;
        public ClientRepository(SportsXsContext context)
        {
            _context = context;
        }
        public async Task UpdateAsync(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await _context.Clients.Include(c => c.Phones).ToListAsync();        
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await _context.Clients.Include(c => c.Phones).SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }
    }
}
