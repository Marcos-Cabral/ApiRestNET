using NETChallenge.Data;
using NETChallenge.Exceptions;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services
{
    public class OrdenDeInversionTipoOperacionService : IOrdenDeInversionTipoOperacionService
    {
         private readonly ContextDB _context;

        public OrdenDeInversionTipoOperacionService(ContextDB context)
        {
            _context = context;
        }
        public void ExisteId(int id)
        {
            if (!_context.OrdenDeInversionOperacion.Any(e=> e.Id == id))
            {
                throw new EntidadNoEncontradaException("No se encontró el tipo de operación para la orden de inversión.");
            }
        }
        public List<OrdenDeInversionOperacion> GetAll()
        {
            return _context.OrdenDeInversionOperacion.ToList();
        }
    }
}
