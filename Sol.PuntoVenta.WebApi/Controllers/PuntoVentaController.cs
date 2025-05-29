using Microsoft.AspNetCore.Mvc;
using Sol.PuntoVenta.Entidades;
using Sol.PuntoVenta.Negocio.Negocios;

namespace Sol.PuntoVenta.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntoVentaController : ControllerBase
    {
        private readonly ILogger<PuntoVentaController> _logger;
        private readonly PuntoVentaN _ventaN;

        public PuntoVentaController(ILogger<PuntoVentaController> logger, PuntoVentaN ventaN)
        {
            _logger = logger;
            _ventaN = ventaN;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(string text)
        {
            Generico generico = new Generico()
            {
                Id = 0,
                Text = text
            };
            GoResponses<List<E_PuntoVenta>> responses = await _ventaN.GetListPuntoVenta(generico);
            if (responses.IsSuccess)
            {
                return Ok(responses);
            }

            return BadRequest(responses);
        }
        [HttpPost]
        public async Task<IActionResult> InPuntoVenta([FromBody]E_PuntoVenta puntoVenta) 
        {
            
            GoResponses<E_PuntoVenta> responses = await _ventaN.InsertUpdatePuntoVenta(puntoVenta);
            if (responses.IsSuccess)
            {
                return Ok(responses);
            }

            return BadRequest(responses);
        }

        [HttpPut]
        public async Task<IActionResult> UdPuntoVenta([FromBody] E_PuntoVenta puntoVenta)
        {

            GoResponses<E_PuntoVenta> responses = await _ventaN.InsertUpdatePuntoVenta(puntoVenta);
            if (responses.IsSuccess)
            {
                return Ok(responses);
            }

            return BadRequest(responses);
        }

        [HttpDelete]
        public async Task<IActionResult> DelPuntoVenta([FromBody] Generico generico)
        {

            GoResponses<bool> responses = await _ventaN.EliminarPuntoVenta(generico);
            if (responses.IsSuccess)
            {
                return Ok(responses);
            }

            return BadRequest(responses);
        }
    }
}
