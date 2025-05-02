using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.Entities
{
    public class Transaccion
    {
        public int IdTransaccion { get; set; }
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoTransaccion { get; set; } = null!;
        public string Estado { get; set; } = null!;

        // Relaciones de navegación
        public Cuenta CuentaOrigen { get; set; } = null!;
        public Cuenta CuentaDestino { get; set; } = null!;
    }
}
