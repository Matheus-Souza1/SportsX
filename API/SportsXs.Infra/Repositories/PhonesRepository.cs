using System;
using System.Threading.Tasks;
using SportsXs.Domain.Entities;
using SportsXs.Domain.Repositories;
using SportsXs.Infra.Persistence;

namespace SportsXs.Infra.Repositories
{
    public class PhonesRepository : IPhonesRepository
    {
        private readonly SportsXsContext _context;
        public PhonesRepository(SportsXsContext context)
        {
            _context = context;
        }
        public async Task Add(Phones phones)
        {
            _context.Phones.Add(phones);
            await _context.SaveChangesAsync();
        }
    }
}