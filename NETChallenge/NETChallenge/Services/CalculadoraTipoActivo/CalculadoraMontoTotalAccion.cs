using NETChallenge.Data;
using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Exceptions;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services.CalculadoraTipoActivo
{
    public class CalculadoraMontoTotalAccion : ICalculadoraTipoActivo
    {
        private readonly AccionService _accionService;

        public CalculadoraMontoTotalAccion(AccionService accionService)
        {
            _accionService = accionService;
        }

        public decimal CalcularMontoTotal(OrdenDeInversionPostRequest req, OrdenDeInversion ordenDeInversion, ContextDB context)
        {
            ValidarAccionObligatoria(req.AccionId);
            var accion = _accionService.GetById(req.AccionId.Value);
            var montoTotalAntesDeComisiones = accion.PrecioUnitario * req.Cantidad;
            var comisiones = montoTotalAntesDeComisiones * Constantes.TarifasFinancieras.ComisionesAcciones;
            var impuestos = comisiones * Constantes.TarifasFinancieras.Impuesto;
            ActualizarCamposDeOrden(ordenDeInversion, accion);
            return Math.Round(montoTotalAntesDeComisiones - comisiones - impuestos, 2);
        }
        public void ValidarAccionObligatoria(int? accionId)
        {
            if (!accionId.HasValue)
                throw new CampoObligatorioException("Acción");
        }

        public void ActualizarCamposDeOrden(OrdenDeInversion req, Accion accion)
        {
            req.Precio = accion.PrecioUnitario; //actualizamos el precio de la orden por el precio de la accion
            req.AccionId = accion.Id; //asigno fk de acción para registrar
        }
    }
}
