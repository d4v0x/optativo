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
    public class ClienteRepository : ICliente
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ClienteModel cliente)
        {
            _context.Clientes.Add(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(ClienteModel cliente)
        {
            _context.Clientes.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ClienteModel> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<ClienteModel>> List()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<bool> Delete(ClienteModel cliente)
        {
            _context.Clientes.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
