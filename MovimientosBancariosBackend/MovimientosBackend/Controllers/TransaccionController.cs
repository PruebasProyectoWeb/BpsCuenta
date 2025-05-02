using Microsoft.AspNetCore.Mvc;
using MovimientosBusiness.Interfaces;
using MovimientosEntities.DTOs;
using MovimientosEntities.DTOsCreate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovimientosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionService _service;

        public TransaccionController(ITransaccionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TransaccionDto>> CrearTransaccion([FromBody] TransaccionCreateDto dto)
        {
            try
            {
                var transaccion = await _service.CrearTransaccionAsync(dto);
                return CreatedAtAction(nameof(CrearTransaccion), new { id = transaccion.IdTransaccion }, transaccion);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
