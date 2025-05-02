using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.DTOs
{
    public class CuentaDTO
    {
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public string NombreTitular { get; set; } = null!;
        public decimal Saldo { get; set; }
        public string EstadoCuenta { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
