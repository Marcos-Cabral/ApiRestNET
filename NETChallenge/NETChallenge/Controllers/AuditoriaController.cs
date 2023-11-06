using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETChallenge.Helpers;
using NETChallenge.Services;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuditoriaController : ControllerBase
    {
        private AuditoriaService _auditoriaService;

        public AuditoriaController(AuditoriaService auditoriaService)
        {
            _auditoriaService = auditoriaService;
        }
        /// <summary>
        /// Endpoint que obtiene las Auditorias del sistema
        /// </summary>
        /// <returns>Lista de Auditorias</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _auditoriaService.GetAll();
            return ResponseHelper.ArmarRespuestaExitosa(list);
        }
    }
}