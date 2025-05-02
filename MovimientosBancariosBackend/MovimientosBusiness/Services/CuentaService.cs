using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovimientosBusiness.Interfaces;
using MovimientosEntities.DTOs;
using MovimientosEntities.DTOsCreate;
using MovimientosEntities.Entities;
using PersistenciaDataBase.AppDBContext;

namespace MovimientosBusiness.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly MovimientoDbContext _context;
        private readonly IMapper _mapper;

        public CuentaService(MovimientoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CuentaDTO>> GetAllCuentasAsync()
        {
            var cuentas = await _context.Cuenta.ToListAsync();
            return _mapper.Map<List<CuentaDTO>>(cuentas);
        }

        public async Task<CuentaDTO> GetCuentaByIdAsync(int id)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta == null) return null;
            return _mapper.Map<CuentaDTO>(cuenta);
        }

        public async Task<CuentaDTO> CreateCuentaAsync(CuentaCreateDto cuentaCreateDto)
        {
            var cuenta = _mapper.Map<Cuenta>(cuentaCreateDto);
            _context.Cuenta.Add(cuenta);
            await _context.SaveChangesAsync();
            return _mapper.Map<CuentaDTO>(cuenta);
        }

        public async Task<CuentaDTO> UpdateCuentaAsync(int id, CuentaCreateDto cuentaCreateDto)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta == null) return null;

            _mapper.Map(cuentaCreateDto, cuenta);
            _context.Cuenta.Update(cuenta);
            await _context.SaveChangesAsync();
            return _mapper.Map<CuentaDTO>(cuenta);
        }

        public async Task<bool> DeleteCuentaAsync(int id)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta == null) return false;

            _context.Cuenta.Remove(cuenta);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
