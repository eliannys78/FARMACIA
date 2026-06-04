using System;

namespace FarmaciaInventario.Domain.Events
{
    public class StockAgotadoEvent
    {
        public Guid MedicamentoId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}