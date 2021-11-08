using SportsXs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsXs.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(Guid id);
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task Delete(Guid id);
    }
}
