using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FarmaciaInventario.Domain.Events;

namespace FarmaciaInventario.Domain.Entities
{
    public class Medicamento
    {
        [DisplayName("Identificador")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [Display(Name = "Nombre del medicamento")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(250, ErrorMessage = "La descripción no puede superar los 250 caracteres.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        [Display(Name = "Cantidad en inventario")]
        public int Stock { get; set; }

        [Range(0.01, 1000000, ErrorMessage = "El precio debe ser mayor que cero.")]
        [Display(Name = "Precio unitario")]
        public decimal Precio { get; set; }

        public List<StockAgotadoEvent> Eventos { get; private set; } = new();

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