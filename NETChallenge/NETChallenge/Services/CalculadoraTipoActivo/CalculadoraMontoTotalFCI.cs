using NETChallenge.Data;
using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services.CalculadoraTipoActivo
{
    public class CalculadoraMontoTotalFCI : ICalculadoraTipoActivo
    {
        public decimal CalcularMontoTotal(OrdenDeInversionPostRequest req, OrdenDeInversion ordenDeInversion, ContextDB context)
        {
            return req.Precio * req.Cantidad;
        }
    }
}
