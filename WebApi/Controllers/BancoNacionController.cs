namespace WebApiBancoNacion.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using WebApiBancoNacion.Models;
    using WebApiBancoNacion.Service;


    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BancoNacionController : ControllerBase
    {
        private readonly IBancoNacionService _service;

        public BancoNacionController(IBancoNacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuotes()
        {
            string resultado = await _service.UpdateQuotesAsync();

            if (resultado == "OK")
            {
                return Ok();
            }

            return this.StatusCode(StatusCodes.Status500InternalServerError, "Se ha producido un error");
        }

        [HttpPost]
        public IActionResult InsertQuote([FromBody] JsonHttpPost cotizacion)
        {
            if (ModelState.IsValid)
            {
                string resultado = _service.InsertQuote(cotizacion);

                if (resultado == "ZERO")
                {
                    return this.StatusCode(StatusCodes.Status400BadRequest, "El ID enviado no corresponde a un Billete");
                   
                }

                return new JsonResult(resultado)
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetQuotes")]
        public IActionResult GetQuotes()
        {
            if (ModelState.IsValid)
            {
                var resultado = _service.GetQuotes();

                if (resultado is null)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "No hay cotizaciones para el dia de la fecha");
                }

                return Ok(resultado);
            }

            return BadRequest(ModelState);
        }
    }
}
