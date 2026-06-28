using FarmaciaInventario.Application.Interfaces;
using FarmaciaInventario.Domain.Entities;

namespace FarmaciaInventario.Application.Services
{
    public class MedicamentoService : IMedicamentoService
    {
        private readonly IMedicamentoRepository _repository;

        public MedicamentoService(IMedicamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Medicamento>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Medicamento?> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Medicamento medicamento)
        {
            medicamento.Id = Guid.NewGuid();

            await _repository.AddAsync(medicamento);
        }

        public async Task UpdateAsync(Medicamento medicamento)
        {
            await _repository.UpdateAsync(medicamento);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}