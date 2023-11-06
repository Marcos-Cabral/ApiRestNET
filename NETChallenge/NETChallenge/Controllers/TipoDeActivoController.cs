using Microsoft.AspNetCore.Mvc;
using NETChallenge.Helpers;
using NETChallenge.Services;
using Microsoft.AspNetCore.Authorization;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoDeActivoController : ControllerBase
    {
        private TipoDeActivoService _tipoDeActivoService;

        public TipoDeActivoController(TipoDeActivoService tipoDeActivoService)
        {
            _tipoDeActivoService = tipoDeActivoService;
        }
        /// <summary>
        /// Endpoint que obtiene los Tipos de Activo del sistema
        /// </summary>
        /// <returns>Lista de Tipos de Activo</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _tipoDeActivoService.GetAll();
            return ResponseHelper.ArmarRespuestaExitosa(list);
        }
    }
}