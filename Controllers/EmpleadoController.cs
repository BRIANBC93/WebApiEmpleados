using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEmpleados.Models;
using WebApiEmpleados.Models.Repository;

namespace WebApiEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet("/Empleado/Index")]
        [ActionName(nameof(GetEmpleadoAsync))]
        public IEnumerable<Empleado> GetEmpleadoAsync()
        {
            try
            {
                return _empleadoRepository.GetEmpleados();
            }
            catch (Exception ex)
            {
                return (IEnumerable<Empleado>)BadRequest(ex);
            }
        }

        [HttpGet("{EmpleadoID}")]
        [ActionName(nameof(GetEmpleadoById))]
        public ActionResult<Empleado> GetEmpleadoById(int EmpleadoID)
        {
            try
            {
                var empleadoByID = _empleadoRepository.GetEmpleadoById(EmpleadoID);
                if (empleadoByID == null)
                {
                    return NotFound();
                }
                return empleadoByID;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [ActionName(nameof(CreateEmpleadoAsync))]
        public async Task<ActionResult<Empleado>> CreateEmpleadoAsync(Empleado empleado)
        {
            try
            {
                await _empleadoRepository.CreateEmpleadoAsync(empleado);
                return CreatedAtAction(nameof(GetEmpleadoById), new { EmpleadoID = empleado.EmpleadoID }, empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{EmpleadoID}")]
        [ActionName(nameof(UpdateEmpleado))]
        public async Task<ActionResult> UpdateEmpleado(int EmpleadoID, Empleado empleado)
        {
            try
            {
                await _empleadoRepository.UpdateEmpleadoAsync(empleado);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
 
        [HttpDelete("{EmpleadoID}")]
        [ActionName(nameof(DeleteEmpleado))]
        public async Task<IActionResult> DeleteEmpleado(int EmpleadoID)
        {
            try
            {
                var empleado = _empleadoRepository.GetEmpleadoById(EmpleadoID);
                if (empleado == null)
                {
                    return NotFound();
                }

                // Actualiza la fecha de baja con la fecha actual
                empleado.FechaBaja = DateTime.Now;
                await _empleadoRepository.UpdateEmpleadoAsync(empleado);

                // Devuelve un objeto JSON indicando que la baja se realizó con éxito
                return Ok(new { message = "El empleado ha sido dado de baja exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [ActionName(nameof(SearchEmpleado))]
        public IActionResult SearchEmpleado(string nombre, string rfc, string estatus)
        {
            try
            {
                // Realiza la búsqueda en función de los criterios proporcionados
                var empleados = _empleadoRepository.SearchEmpleados(nombre, rfc, estatus);

                return Ok(empleados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
