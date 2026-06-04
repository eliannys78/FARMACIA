using FarmaciaInventario.Application.Interfaces;
using FarmaciaInventario.Domain.Entities;
using FarmaciaInventario.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaInventario.Infrastructure.Repositories
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly FarmaciaDbContext _context;

        public MedicamentoRepository(FarmaciaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicamento>> GetAllAsync()
        {
            return await _context.Medicamentos.ToListAsync();
        }

        public async Task<Medicamento?> GetByIdAsync(Guid id)
        {
            return await _context.Medicamentos.FindAsync(id);
        }

        public async Task AddAsync(Medicamento medicamento)
        {
            await _context.Medicamentos.AddAsync(medicamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medicamento medicamento)
        {
            _context.Medicamentos.Update(medicamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);

            if (medicamento != null)
            {
                _context.Medicamentos.Remove(medicamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}