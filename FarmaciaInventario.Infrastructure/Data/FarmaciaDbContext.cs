using Microsoft.EntityFrameworkCore;
using FarmaciaInventario.Domain.Entities;

namespace FarmaciaInventario.Infrastructure.Data
{
    public class FarmaciaDbContext : DbContext
    {
        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Medicamento> Medicamentos { get; set; }
    }
}