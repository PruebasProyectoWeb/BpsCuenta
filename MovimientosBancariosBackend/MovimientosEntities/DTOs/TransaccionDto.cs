using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.DTOs
{
    public class TransaccionDto
    {
        public int IdTransaccion { get; set; }
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoTransaccion { get; set; } = null!;
        public string Estado { get; set; } = null!;
    }
}
