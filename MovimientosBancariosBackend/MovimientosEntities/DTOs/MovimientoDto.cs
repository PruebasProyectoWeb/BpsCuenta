using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.DTOs
{
    public class MovimientoDto
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public int IdTransaccion { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
