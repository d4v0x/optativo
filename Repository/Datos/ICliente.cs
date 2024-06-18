using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public interface ICliente
    {
        Task<bool> Add(ClienteModel cliente);
        Task<bool> Update(ClienteModel cliente);
        Task<ClienteModel> Get(int id);
        Task<IEnumerable<ClienteModel>> List();
        Task<bool> Delete(ClienteModel cliente);
    }
}
