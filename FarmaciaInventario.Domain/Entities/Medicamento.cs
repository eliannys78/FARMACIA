using FarmaciaInventario.Domain.Events;

namespace FarmaciaInventario.Domain.Entities
{
    public class Medicamento
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public int Stock { get; set; }

        public decimal Precio { get; set; }

        public List<StockAgotadoEvent> Eventos { get; private set; }
            = new();

        public void ReducirStock(int cantidad)
        {
            Stock -= cantidad;

            if (Stock <= 0)
            {
                Eventos.Add(new StockAgotadoEvent
                {
                    MedicamentoId = Id
                });
            }
        }
    }
}