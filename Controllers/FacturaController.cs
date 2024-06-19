using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Datos;
using Services.Logica;

namespace examen_parcial3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(FacturaModel factura)
        {
            var result = await _facturaService.Add(factura);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<FacturaModel>>> GetAll()
        {
            return await _facturaService.GetAllFacturas();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaModel>> Get(int id)
        {
            var factura = await _facturaService.Get(id);
            if (factura != null)
                return Ok(factura);
            else
                return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(FacturaModel factura)
        {
            var result = await _facturaService.Update(factura);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _facturaService.Delete(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
