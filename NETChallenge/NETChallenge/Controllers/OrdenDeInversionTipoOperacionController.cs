using Microsoft.AspNetCore.Mvc;
using NETChallenge.Helpers;
using NETChallenge.Services;
using Microsoft.AspNetCore.Authorization;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdenDeInversionTipoOperacionController : ControllerBase
    {
        private OrdenDeInversionTipoOperacionService _ordenDeInversionTipoOperacionService;

        public OrdenDeInversionTipoOperacionController(OrdenDeInversionTipoOperacionService ordenDeInversionTipoOperacionService)
        {
            _ordenDeInversionTipoOperacionService = ordenDeInversionTipoOperacionService;
        }

        /// <summary>
        /// Endpoint que obtiene los Tipos de Operación de las Ordenes de Inversión del sistema
        /// </summary>
        /// <returns>Lista de Tipos de Operación de las Ordenes de Inversión</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _ordenDeInversionTipoOperacionService.GetAll();
            return ResponseHelper.ArmarRespuestaExitosa(list);
        }
    }
}