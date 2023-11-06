using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETChallenge.Helpers;
using NETChallenge.Services;
using Swashbuckle.Swagger.Annotations;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccionController : ControllerBase
    {
        private AccionService _accionService;

        public AccionController(AccionService accionService)
        {
            _accionService = accionService;
        }

        /// <summary>
        /// Endpoint que obtiene las Acciones del sistema
        /// </summary>
        /// <returns>Lista de Acciones</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _accionService.GetAll();
            return ResponseHelper.ArmarRespuestaExitosa(list);
        }

        /// <summary>
        /// Endpoint que obtiene una Acción del sistema por Id
        /// </summary>
        /// <param name="id">Id de la Acción</param>
        /// <returns>Acción</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estadoOrden = _accionService.GetById(id);
            return ResponseHelper.ArmarRespuestaExitosa(estadoOrden);
        }
    }
}