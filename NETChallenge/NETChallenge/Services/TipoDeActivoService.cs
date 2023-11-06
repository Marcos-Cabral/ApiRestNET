using NETChallenge.Data;
using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Enums;
using NETChallenge.Exceptions;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;
using NETChallenge.Services.CalculadoraTipoActivo;

namespace NETChallenge.Services
{
    public class TipoDeActivoService : ITipoDeActivoService
    {
        private readonly ContextDB _context;
        private readonly AccionService _accionService;

        public TipoDeActivoService(ContextDB context, AccionService accionService)
        {
            _context = context;
            _accionService = accionService;
        }

        public void ExisteId(int id)
        {
            if (!_context.TipoDeActivo.Any(e=> e.Id == id))
            {
                throw new EntidadNoEncontradaException("No se encontró el tipo de activo.");
            }
        }
        private ICalculadoraTipoActivo ObtenerCalculadoraParaTipoActivo(int tipoActivoId, AccionService accionService)
        {
            return tipoActivoId switch
            {
                (int)TiposActivos.FCI => new CalculadoraMontoTotalFCI(),
                (int)TiposActivos.Accion => new CalculadoraMontoTotalAccion(accionService),
                (int)TiposActivos.Bono => new CalculadoraMontoTotalBono(),
                _ => throw new TipoDeActivoInvalidoException(),
            };
        }
        public decimal GetMontoTotal(OrdenDeInversionPostRequest req, OrdenDeInversion ordenDeInversion)
        {
            ICalculadoraTipoActivo calculadora = ObtenerCalculadoraParaTipoActivo(req.TipoActivoId, _accionService);
            return calculadora.CalcularMontoTotal(req, ordenDeInversion, _context);
        }

        public List<TipoDeActivo> GetAll()
        {
            return _context.TipoDeActivo.ToList();
        }
    }
}
