using System;

namespace FarmaciaInventario.Domain.ValueObjects
{
    public class Precio
    {
        public decimal Valor { get; }

        public Precio(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero");

            Valor = valor;
        }
    }
}