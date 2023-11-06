using Microsoft.AspNetCore.Mvc;
using NETChallenge.Dto.OrdenDeInversion;
using Microsoft.AspNetCore.Authorization;
using NETChallenge.Helpers;
using NETChallenge.Services;
using System.Security.Claims;
using challenge.Filters;
using challenge.Mapper;
using NETChallenge.Models;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(TokenUserFilter))] 
    public class OrdenDeInversionController : ControllerBase
    {
        private OrdenDeInversionService _ordenDeInversionService;

        public OrdenDeInversionController(OrdenDeInversionService ordenDeInversionService)
        {
            _ordenDeInversionService = ordenDeInversionService;
        }
        /// <summary>
        /// Endpoint que obtiene las Ordenes de Inversi�n del sistema
        /// </summary>
        /// <returns>Lista de Ordenes de Inversi�n</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] OrdenDeInversionFiltroDto req)
        {
            var usuarioId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var list = _ordenDeInversionService.GetAll(req);
            return ResponseHelper.ArmarRespuestaExitosa(list);
        }

        /// <summary>
        /// Endpoint que obtiene una Orden de Inversi�n del sistema por Id
        /// </summary>
        /// <param name="id">Id de la Orden de Inversi�n</param>
        /// <returns>Orden de Inversi�n</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ordenDeInversion = _ordenDeInversionService.GetById(id);
            return ResponseHelper.ArmarRespuestaExitosa(OrdenDeInversionMapper.Map(ordenDeInversion));
        }
        /// <summary>
        /// Endpoint que crea una Orden de Inversi�n
        /// </summary>
        /// <returns>Orden de Inversi�n</returns>
        [HttpPost]
        public IActionResult Post([FromBody] OrdenDeInversionPostRequest req)
        {
            var ordenDeInversion = _ordenDeInversionService.Create(req);
            return ResponseHelper.ArmarRespuestaExitosa(ordenDeInversion);
        }
        /// <summary>
        /// Endpoint que modifica una Orden de Inversi�n
        /// </summary>
        /// <returns>Orden de Inversi�n</returns>
        [HttpPut]
        public IActionResult Put([FromBody] OrdenDeInversionPutRequest req)
        {
            var ordenDeInversion = _ordenDeInversionService.Put(req);
            return ResponseHelper.ArmarRespuestaExitosa(ordenDeInversion);
        }
         /// <summary>
        /// Endpoint que elimina una Orden de Inversi�n
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminoOrdenInversion = _ordenDeInversionService.Delete(id);
            return ResponseHelper.ArmarRespuestaExitosa(eliminoOrdenInversion);
        }
    }
}