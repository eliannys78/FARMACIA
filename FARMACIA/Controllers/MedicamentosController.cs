using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FarmaciaInventario.Domain.Entities;
using FarmaciaInventario.Application.Interfaces;

namespace FARMACIA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentoRepository _repository;

        public MedicamentosController(IMedicamentoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicamento>>> GetMedicamentos()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medicamento>> GetMedicamento(Guid id)
        {
            var medicamento = await _repository.GetByIdAsync(id);

            if (medicamento == null)
                return NotFound();

            return medicamento;
        }

        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento(Medicamento medicamento)
        {
            medicamento.Id = Guid.NewGuid();

            await _repository.AddAsync(medicamento);

            return CreatedAtAction(
                nameof(GetMedicamento),
                new { id = medicamento.Id },
                medicamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamento(Guid id, Medicamento medicamento)
        {
            if (id != medicamento.Id)
                return BadRequest();

            await _repository.UpdateAsync(medicamento);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamento(Guid id)
        {
            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}