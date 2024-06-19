using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Datos;
using Services.Logica;

namespace examen_parcial3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClienteModel cliente)
        {
            var result = await _clienteService.Add(cliente);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> GetAll()
        {
            return await _clienteService.GetAllClientes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> Get(int id)
        {
            var cliente = await _clienteService.Get(id);
            if (cliente != null)
                return Ok(cliente);
            else
                return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClienteModel cliente)
        {
            var result = await _clienteService.Update(cliente);
            if (result)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clienteService.Delete(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
