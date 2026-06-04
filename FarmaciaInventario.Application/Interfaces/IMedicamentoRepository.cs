using FarmaciaInventario.Domain.Entities;

namespace FarmaciaInventario.Application.Interfaces
{
    public interface IMedicamentoRepository
    {
        Task<List<Medicamento>> GetAllAsync();

        Task<Medicamento?> GetByIdAsync(Guid id);

        Task AddAsync(Medicamento medicamento);

        Task UpdateAsync(Medicamento medicamento);

        Task DeleteAsync(Guid id);
    }
}