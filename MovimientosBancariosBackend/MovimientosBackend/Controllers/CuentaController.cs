using Microsoft.AspNetCore.Mvc;
using MovimientosBusiness.Interfaces;
using MovimientosEntities.DTOs;
using MovimientosEntities.DTOsCreate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovimientosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }

        // GET: api/Cuenta
        [HttpGet]
        public async Task<ActionResult<List<CuentaDTO>>> GetCuentas()
        {
            var cuentas = await _cuentaService.GetAllCuentasAsync();
            return Ok(cuentas);
        }

        // GET: api/Cuenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaDTO>> GetCuenta(int id)
        {
            var cuenta = await _cuentaService.GetCuentaByIdAsync(id);
            if (cuenta == null) return NotFound();
            return Ok(cuenta);
        }

        // POST: api/Cuenta
        [HttpPost]
        public async Task<ActionResult<CuentaDTO>> PostCuenta(CuentaCreateDto cuentaCreateDto)
        {
            var cuenta = await _cuentaService.CreateCuentaAsync(cuentaCreateDto);
            return CreatedAtAction(nameof(GetCuenta), new { id = cuenta.IdCuenta }, cuenta);
        }

        // PUT: api/Cuenta/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CuentaDTO>> PutCuenta(int id, CuentaCreateDto cuentaCreateDto)
        {
            var cuenta = await _cuentaService.UpdateCuentaAsync(id, cuentaCreateDto);
            if (cuenta == null) return NotFound();
            return Ok(cuenta);
        }

        // DELETE: api/Cuenta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            var result = await _cuentaService.DeleteCuentaAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }
}
