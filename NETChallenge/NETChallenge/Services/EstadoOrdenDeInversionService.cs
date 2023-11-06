using NETChallenge.Data;
using NETChallenge.Exceptions;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services
{
    public class EstadoOrdenDeInversionService : IEstadoOrdenDeInversionService
    {
        private readonly ContextDB _context;

        public EstadoOrdenDeInversionService(ContextDB context)
        {
            _context = context;
        }

        public List<EstadoOrdenDeInversion> GetAll()
        {
            return _context.EstadoOrdenDeInversion.ToList();
        }

        public EstadoOrdenDeInversion GetById(int id)
        {
            var estado = _context.EstadoOrdenDeInversion.FirstOrDefault(e=> e.Id == id);
            if (estado == null)
            {
                throw new EntidadNoEncontradaException("No se encontró el estado de orden de inversión");
            }
            return estado;
        }
        public void ExisteId(int id)
        {
            if (!_context.EstadoOrdenDeInversion.Any(e=> e.Id == id))
            {
                throw new EntidadNoEncontradaException("No se encontró el estado de orden de inversión");
            }
        }
    }
}