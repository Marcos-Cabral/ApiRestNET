using NETChallenge.Dto.OrdenDeInversion;
using NETChallenge.Models;

namespace NETChallenge.Interfaces.Services
{
    public interface ITipoDeActivoService
    {
        void ExisteId(int id);
        decimal GetMontoTotal(OrdenDeInversionPostRequest req, OrdenDeInversion ordenDeInversion);
        List<TipoDeActivo> GetAll();
    }
}
