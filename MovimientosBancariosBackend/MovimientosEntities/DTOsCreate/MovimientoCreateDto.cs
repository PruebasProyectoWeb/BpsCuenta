using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.DTOsCreate
{
    public class MovimientoCreateDto
    {
        public int IdCuenta { get; set; }
        public int IdTransaccion { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal Monto { get; set; }
    }
}
