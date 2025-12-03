using Microsoft.EntityFrameworkCore;
using ProcessoDigital.Data.Context;
using ProcessoDigital.Data.Model;
using ProcessoDigital.Services.Interfaces;

namespace ProcessoDigital.Services.Implementations
{
    public class AndamentoService: IAndamentoService
    {
        private readonly AppDbContext _context;

        public AndamentoService(AppDbContext context)
        {
            _context = context;
        }
        // Em AndamentoService.cs

        public async Task<IEnumerable<Andamento>> GetAllAndamentosAsync()
        {
            // Inclui o Processo relacionado para que possamos mostrar o Número CNJ no Dashboard
            return await _context.Andamentos
                .Include(a => a.Processo)
                .ToListAsync();
        }
        public async Task<IEnumerable<Andamento>> GetByProcessoIdAsync(int processoId)
        {
            return await _context.Andamentos
                .Include(p => p.Processo)
                .Where(p => p.ProcessoId == processoId)
                .ToListAsync();
        }

        public async Task<Andamento?> GetByIdAsync(int id)
        {
            return await _context.Andamentos
                .Include(a => a.Descricao)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(Andamento andamento)
        {
            _context.Andamentos.Add(andamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Andamento andamento)
        {
            _context.Andamentos.Update(andamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var andamento = await _context.Andamentos.FindAsync(id);
            if (andamento != null)
            {
                _context.Andamentos.Remove(andamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
