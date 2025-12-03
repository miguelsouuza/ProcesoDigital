using ProcessoDigital.Data.Model;

namespace ProcessoDigital.Services.Interfaces
{
    public interface IProcessoService
    {
        Task<IEnumerable<Processo>> GetAllAsync();
        Task<IEnumerable<Processo>> GetByClienteIdAsync(int clienteId);
        Task<Processo?> GetByIdAsync(int id);
        Task AddAsync(Processo processo);
        Task UpdateAsync(Processo processo);
        Task DeleteAsync(int id);
    }
}
