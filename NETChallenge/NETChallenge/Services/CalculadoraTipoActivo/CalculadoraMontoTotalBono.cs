using NETChallenge.Data;
using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services.CalculadoraTipoActivo
{
    public class CalculadoraMontoTotalBono : ICalculadoraTipoActivo
    {
        public decimal CalcularMontoTotal(OrdenDeInversionPostRequest req ,OrdenDeInversion ordenDeInversion, ContextDB context)
        {
            var comisiones = req.Precio * req.Cantidad * Constantes.TarifasFinancieras.ComisionesBono;
            var impuestos = comisiones * Constantes.TarifasFinancieras.Impuesto;
            return req.Precio * req.Cantidad - comisiones - impuestos;
        }
    }
}
