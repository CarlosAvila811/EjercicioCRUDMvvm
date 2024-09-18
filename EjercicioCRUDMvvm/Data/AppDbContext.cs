using Microsoft.EntityFrameworkCore;
using EjercicioCRUDMvvm.Models;

namespace EjercicioCRUDMvvm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Proveedor> Proveedores { get; set; }
    }
}
