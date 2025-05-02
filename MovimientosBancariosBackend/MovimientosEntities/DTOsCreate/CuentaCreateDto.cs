using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.DTOsCreate
{
    public class CuentaCreateDto
    {
        public string NumeroCuenta { get; set; } = null!;
        public string NombreTitular { get; set; } = null!;
        public decimal Saldo { get; set; }
    }
}
