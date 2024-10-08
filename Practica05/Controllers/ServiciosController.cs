using Microsoft.AspNetCore.Mvc;
using Practica05.Data.Models;
using Practica05.Data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioService _service;

        public ServiciosController(IServicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.RecuperarEnPromo());
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var serExists = _service.RecuperarPorID(id);
                if(serExists != null)
                {
                    return Ok(serExists);
                }
                else
                {
                    return BadRequest($"No se encontro ningun registro con el id {id}");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] TServicio oServicio)
        {
            try
            {
                return Ok(_service.AgregarServicio(oServicio));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TServicio oServicio)
        {
            try
            {
                return Ok(_service.ActualizarServicio(oServicio, id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_service.SacarPromocion(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }
    }
}
