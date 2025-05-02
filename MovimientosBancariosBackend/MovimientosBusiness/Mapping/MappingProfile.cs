using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovimientosEntities.DTOs;
using MovimientosEntities.DTOsCreate;
using MovimientosEntities.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovimientosBusiness.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            // Mapeo de Cuenta
            CreateMap<Cuenta, CuentaDTO>();
            CreateMap<CuentaCreateDto, Cuenta>();

            // Mapeo de Transaccion
            CreateMap<Transaccion, TransaccionDto>();
            CreateMap<TransaccionCreateDto, Transaccion>();

            // Mapeo de Movimiento
            CreateMap<Movimiento, MovimientoDto>();
            CreateMap<MovimientoCreateDto, Movimiento>();
        }
        
    }
}
