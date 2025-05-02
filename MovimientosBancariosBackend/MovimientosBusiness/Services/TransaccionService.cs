using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovimientosBusiness.Interfaces;
using MovimientosEntities.DTOs;
using MovimientosEntities.DTOsCreate;
using MovimientosEntities.Entities;
using PersistenciaDataBase.AppDBContext;

namespace MovimientosBusiness.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly MovimientoDbContext _context;
        private readonly IMapper _mapper;

        public TransaccionService(MovimientoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TransaccionDto> CrearTransaccionAsync(TransaccionCreateDto dto)
        {
            // Verificar que las cuentas existan
            var cuentaOrigen = await _context.Cuenta.FindAsync(dto.IdCuentaOrigen);
            var cuentaDestino = await _context.Cuenta.FindAsync(dto.IdCuentaDestino);

            if (cuentaOrigen == null || cuentaDestino == null)
                throw new Exception("Una o ambas cuentas no existen.");

            if (cuentaOrigen.Saldo < dto.Monto)
                throw new Exception("Saldo insuficiente en la cuenta origen.");

            // Actualizar saldos
            cuentaOrigen.Saldo -= dto.Monto;
            cuentaDestino.Saldo += dto.Monto;

            // Crear la transacción
            var transaccion = new Transaccion
            {
                IdCuentaOrigen = dto.IdCuentaOrigen,
                IdCuentaDestino = dto.IdCuentaDestino,
                Monto = dto.Monto,
                TipoTransaccion = dto.TipoTransaccion,
                Estado = "Exitosa",
                Fecha = DateTime.UtcNow
            };

            _context.Transaccion.Add(transaccion);
            await _context.SaveChangesAsync();

            return _mapper.Map<TransaccionDto>(transaccion);
        }
    }
}
