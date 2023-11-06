using Microsoft.AspNetCore.Mvc;
using NETChallenge.Helpers;
using NETChallenge.Services;
using Microsoft.AspNetCore.Authorization;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoOperacionAuditoriaController : ControllerBase
    {
        private TipoOperacionAuditoriaService _tipoOperacionAuditoriaService;

        public TipoOperacionAuditoriaController(TipoOperacionAuditoriaService tipoOperacionAuditoriaService)
        {
            _tipoOperacionAuditoriaService = tipoOperacionAuditoriaService;
        }

        /// <summary>
        /// Endpoint que obtiene los Tipos de Operación de Auditoria del sistema
        /// </summary>
        /// <returns>Lista de Tipos de Operación de Auditoria</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _tipoOperacionAuditoriaService.GetAll();
            return ResponseHelper.ArmarRespuestaExitosa(list);
        }
    }
}