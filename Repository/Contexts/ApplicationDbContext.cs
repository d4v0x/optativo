using Microsoft.EntityFrameworkCore;
using Repository.Datos;
using System.Collections.Generic;

namespace MyProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<FacturaModel> Facturas { get; set; }
    }
}
