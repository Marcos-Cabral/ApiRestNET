using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETChallenge.Helpers;
using NETChallenge.Services;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstadoOrdenDeInversionController : ControllerBase
    {
        private EstadoOrdenDeInversionService _estadoOrdenDeInversionService;

        public EstadoOrdenDeInversionController(EstadoOrdenDeInversionService estadoOrdenDeInversionService)
        {
            _estadoOrdenDeInversionService = estadoOrdenDeInversionService;
        }

        /// <summary>
        /// Endpoint que obtiene los Estados de las Ordenes de Inversión del sistema
        /// </summary>
        /// <returns>Lista de Acciones</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _estadoOrdenDeInversionService.GetAll();
            return ResponseHelper.ArmarRespuestaExitosa(list);
        }

         /// <summary>
        /// Endpoint que obtiene un Estado de Orden de Inversión del sistema
        /// </summary>
        /// <param name="id">Id del Estado</param>
        /// <returns>Estado de Orden de Inversión</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estadoOrden = _estadoOrdenDeInversionService.GetById(id);
            return ResponseHelper.ArmarRespuestaExitosa(estadoOrden);
        }
    }
}