using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using Npgsql;

namespace Repository.Datos
{
    public class FacturaRepository : IFactura
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(FacturaModel factura)
        {
            _context.Facturas.Add(factura);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(FacturaModel factura)
        {
            _context.Facturas.Update(factura);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<FacturaModel> Get(int id)
        {
            return await _context.Facturas.FindAsync(id);
        }

        public async Task<IEnumerable<FacturaModel>> List()
        {
            return await _context.Facturas.ToListAsync();
        }

        public async Task<bool> Delete(FacturaModel factura)
        {
            _context.Facturas.Remove(factura);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}