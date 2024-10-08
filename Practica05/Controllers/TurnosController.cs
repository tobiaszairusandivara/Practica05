using Practica05.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Practica05.Data.Models;
using Practica05.Data.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _service;

        public TurnosController(ITurnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var turnos = _service.GetAll(); 
                return Ok(turnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var turExists = _service.VerificarTurno(id); 
                if (turExists == null)
                {
                    return NotFound($"No se ha encontrado ningún turno con id: {id}");
                }
                return Ok(turExists);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            try
            {
                var turnCreate = _service.Create(turno);
                return Ok(turnCreate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion : {ex}");
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TTurno oTurno)
        {
            try
            {
                var turExists =  _service.VerificarTurno(id); 
                if (turExists == null)
                {
                    return NotFound($"No se ha encontrado ningún turno con id: {id}");
                }

                var result =  _service.Update(oTurno, id); 
                if (result)
                {
                    return Ok("El turno ha sido actualizado con éxito.");
                }
                return StatusCode(500, "No se pudo actualizar el turno.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] string motivo)
        {
            try
            {
                var turExists =  _service.VerificarTurno(id); 
                if (turExists == null)
                {
                    return NotFound($"No se ha encontrado ningún turno con id: {id}");
                }

                var result =  _service.Delete(id, motivo); 
                if (result)
                {
                    return Ok($"Se eliminó con éxito el turno con id: {id}");
                }
                return StatusCode(500, "No se pudo eliminar el turno.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno! Excepcion: {ex.Message}");
            }
        }
    }
}