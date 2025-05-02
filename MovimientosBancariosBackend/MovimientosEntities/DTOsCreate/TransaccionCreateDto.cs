using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.DTOsCreate
{
    public class TransaccionCreateDto
    {
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public string TipoTransaccion { get; set; } = null!;
    }
}
