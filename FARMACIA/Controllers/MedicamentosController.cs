using FarmaciaInventario.Application.Interfaces;
using FarmaciaInventario.Application.Services;
using FarmaciaInventario.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FARMACIA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentosController : ControllerBase
    {
        private readonly IMedicamentoService _service;

        public MedicamentosController(IMedicamentoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene la lista de todos los medicamentos registrados.
        /// </summary>
        /// <returns>Lista de medicamentos.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Medicamento>>> GetMedicamentos()
        {
            return await _service.GetAllAsync();
        }

        /// <summary>
        /// Obtiene un medicamento por su identificador.
        /// </summary>
        /// <param name="id">Identificador del medicamento.</param>
        /// <returns>Medicamento encontrado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Medicamento>> GetMedicamento(Guid id)
        {
            var medicamento = await _service.GetByIdAsync(id);

            if (medicamento == null)
                return NotFound();

            return medicamento;
        }

        /// <summary>
        /// Registra un nuevo medicamento.
        /// </summary>
        /// <param name="medicamento">Datos del medicamento.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Medicamento>> PostMedicamento(Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddAsync(medicamento);

            return CreatedAtAction(
                nameof(GetMedicamento),
                new { id = medicamento.Id },
                medicamento);
        }

        /// <summary>
        /// Actualiza un medicamento existente.
        /// </summary>
        /// <param name="id">Identificador del medicamento.</param>
        /// <param name="medicamento">Datos actualizados.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutMedicamento(Guid id, Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicamento.Id)
            {
                return BadRequest("El ID de la URL no coincide con el ID del medicamento.");
            }

            await _service.UpdateAsync(medicamento);

            return NoContent();
        }

        /// <summary>
        /// Elimina un medicamento por su identificador.
        /// </summary>
        /// <param name="id">Identificador del medicamento.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteMedicamento(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}