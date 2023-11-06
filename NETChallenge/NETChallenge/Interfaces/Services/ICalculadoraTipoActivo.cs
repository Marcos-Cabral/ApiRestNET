using NETChallenge.Data;
using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Models;

namespace NETChallenge.Interfaces.Services
{
    public interface ICalculadoraTipoActivo
    {
        decimal CalcularMontoTotal(OrdenDeInversionPostRequest req, OrdenDeInversion ordenDeInversion, ContextDB context);
    }
}
