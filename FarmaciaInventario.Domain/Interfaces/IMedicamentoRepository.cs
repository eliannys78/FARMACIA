using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FarmaciaInventario.Domain.Entities;

namespace FarmaciaInventario.Domain.Interfaces
{
    public interface IMedicamentoRepository
    {
        Task<IEnumerable<Medicamento>> ObtenerTodos();

        Task<Medicamento> ObtenerPorId(Guid id);

        Task Agregar(Medicamento medicamento);

        Task Actualizar(Medicamento medicamento);

        Task Eliminar(Guid id);
    }
}