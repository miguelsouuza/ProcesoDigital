using Microsoft.EntityFrameworkCore;
using ProcessoDigital.Data.Context;
using ProcessoDigital.Data.Model;
using ProcessoDigital.Services.Interfaces;

namespace ProcessoDigital.Services.Implementations
{
    public class ProcessoService : IProcessoService
    {
        private readonly AppDbContext _context;

        public ProcessoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Processo>> GetAllAsync()
        {
            return await _context.Processos
                .Include(p => p.Andamentos)
                .ToListAsync();
        }
        public async Task<IEnumerable<Processo>> GetByClienteIdAsync(int clienteId)
        {
            return await _context.Processos
                .Include(p => p.Andamentos)
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<Processo?> GetByIdAsync(int id)
        {
            return await _context.Processos
                .Include(p => p.Andamentos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Processo processo)
        {
            _context.Processos.Add(processo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Processo processo)
        {
            _context.Processos.Update(processo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var processo = await _context.Processos.FindAsync(id);
            if (processo != null)
            {
                _context.Processos.Remove(processo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
