using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovimientosEntities.DTOs;
using MovimientosEntities.DTOsCreate;

namespace MovimientosBusiness.Interfaces
{
    public interface ITransaccionService
    {
        Task<TransaccionDto> CrearTransaccionAsync(TransaccionCreateDto transaccionCreateDto);

    }
}
