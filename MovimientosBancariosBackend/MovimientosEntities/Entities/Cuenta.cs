using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimientosEntities.Entities
{
    public class Cuenta
    {
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public string NombreTitular { get; set; } = null!;
        public decimal Saldo { get; set; }
        public string EstadoCuenta { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
    }
}
