using FarmaciaInventario.Domain.Entities;

namespace FarmaciaInventario.Application.Services
{
    public interface IMedicamentoService
    {
        Task<List<Medicamento>> GetAllAsync();

        Task<Medicamento?> GetByIdAsync(Guid id);

        Task AddAsync(Medicamento medicamento);

        Task UpdateAsync(Medicamento medicamento);

        Task DeleteAsync(Guid id);
    }
}