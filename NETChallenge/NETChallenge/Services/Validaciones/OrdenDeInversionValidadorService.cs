using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Enums;
using NETChallenge.Exceptions;

namespace NETChallenge.Services.Validaciones
{
    public class OrdenDeInversionValidadorService
    {
        private readonly ValidadorDeNumerosService _validadorDeNumerosService;
        private readonly TipoDeActivoService _tipoDeActivoService;
        private readonly OrdenDeInversionTipoOperacionService _ordenDeInversionOperacionService;

         public OrdenDeInversionValidadorService(ValidadorDeNumerosService validadorDeNumerosService, TipoDeActivoService tipoDeActivoService, OrdenDeInversionTipoOperacionService ordenDeInversionOperacionService)
        {
            _validadorDeNumerosService = validadorDeNumerosService;
            _tipoDeActivoService = tipoDeActivoService;
            _ordenDeInversionOperacionService = ordenDeInversionOperacionService;
        }

        public void ValidarCreacion(OrdenDeInversionPostRequest req)
        {
            _tipoDeActivoService.ExisteId(req.TipoActivoId);
            _ordenDeInversionOperacionService.ExisteId(req.OrdenDeInversionOperacionId);
            _validadorDeNumerosService.ValidarNumeroMayorAOtro("Cantidad", req.Cantidad, 0);
            if(req.TipoActivoId != (int) TiposActivos.Accion) //en las acciones ignoramos el precio
            {
                _validadorDeNumerosService.ValidarNumeroMayorAOtro("Precio", req.Precio, 0);
            }
        }

        public void ValidarMontoTotal(decimal montoTotal)
        {
            _validadorDeNumerosService.ValidarNumeroMayorAOtro("Precio", montoTotal, 0);
        }
        public void ValidarEliminacion(DateTime? fechaBaja)
        {
            if (fechaBaja.HasValue)
            {
                throw new EntidadYaEliminadaException();
            }
        }
    }
}
