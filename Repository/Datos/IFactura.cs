using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Datos
{
    public interface IFactura
    {
        Task<bool> Add(FacturaModel factura);
        Task<bool> Update(FacturaModel factura);
        Task<FacturaModel> Get(int id);
        Task<IEnumerable<FacturaModel>> List();
        Task<bool> Delete(FacturaModel factura);
    }
}
