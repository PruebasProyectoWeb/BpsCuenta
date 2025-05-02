using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovimientosEntities.DTOs;
using MovimientosEntities.DTOsCreate;

namespace MovimientosBusiness.Interfaces
{
    public interface ICuentaService
    {
        Task<List<CuentaDTO>> GetAllCuentasAsync();
        Task<CuentaDTO> GetCuentaByIdAsync(int id);
        Task<CuentaDTO> CreateCuentaAsync(CuentaCreateDto cuentaCreateDto);
        Task<CuentaDTO> UpdateCuentaAsync(int id, CuentaCreateDto cuentaCreateDto);
        Task<bool> DeleteCuentaAsync(int id);
    }
}
