using Api.BLL.Service;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Web.Controllers
{
    /// <summary>
    /// Todo Sobre Empleados
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _service;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _service = empleadoService;
        }

        /// <summary>
        /// Mostrar todos los empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            IQueryable<Empleado> consultaEmpleadoSql = await _service.ObtenerTodos();
            List<Empleado> lista = consultaEmpleadoSql.Select(e => new Empleado()
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Edad = e.Edad,
                Dni = e.Dni,
                Email = e.Email
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }
        /// <summary>
        /// Mostrar un Empleado por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            Empleado respuesta = await _service.Obtener(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        /// <summary>
        ///  Insertar un nuevo empleado
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Editar")]
        public async Task<IActionResult> Insertar([FromBody] Empleado modelo)
        {
            Empleado NuevoModelo = new Empleado()
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Edad = modelo.Edad,
                Dni = modelo.Dni,
                Email = modelo.Email
            };

            bool respuesta = await _service.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        /// <summary>
        /// Modificar un empleado
        /// </summary>
        /// <param name="modelo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Guardar")]
        public async Task<IActionResult> Actualizar([FromBody] Empleado modelo)
        {
            Empleado NuevoModelo = new Empleado()
            {
                Nombre = modelo.Nombre,
                Apellido = modelo.Apellido,
                Edad = modelo.Edad,
                Dni = modelo.Dni,
                Email = modelo.Email
            };

            bool respuesta = await _service.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        
        /// <summary>
        /// Eliminar un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _service.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }
}
