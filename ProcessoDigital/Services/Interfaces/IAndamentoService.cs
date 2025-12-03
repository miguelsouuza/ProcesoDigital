using ProcessoDigital.Data.Model;

namespace ProcessoDigital.Services.Interfaces
{
    public interface IAndamentoService
    {
        Task<IEnumerable<Andamento>> GetAllAndamentosAsync();
        Task<IEnumerable<Andamento>> GetByProcessoIdAsync(int processoId);
        Task<Andamento?> GetByIdAsync(int id);
        Task AddAsync(Andamento andamento);
        Task UpdateAsync(Andamento andamento);
        Task DeleteAsync(int id);
    }
}
