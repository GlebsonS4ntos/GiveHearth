using GiveHearth.Context;
using GiveHearth.Interfaces;
using GiveHearth.Models;
using Microsoft.EntityFrameworkCore;

namespace GiveHearth.Repositories
{
    public class RepositoryRegister : RepositoryBase<Register>, IRepositoryRegister
    {
        private readonly DataContext _context;

        public RepositoryRegister(DataContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task<List<Register>> GetAllByCpfAsync(string cpf)
        {
            return await _context.registrations.Where(r => r.Cpf == cpf).ToListAsync();
        }
    }
}
