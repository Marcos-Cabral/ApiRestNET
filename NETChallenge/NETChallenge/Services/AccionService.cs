using NETChallenge.Data;
using NETChallenge.Exceptions;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services
{
    public class AccionService : IAccionService
    {
        private readonly ContextDB _context;

        public AccionService(ContextDB context)
        {
            _context = context;
        }

        public List<Accion> GetAll()
        {
            return _context.Accion.ToList();
        }

        public Accion GetById(int id)
        {
            var accion = _context.Accion.FirstOrDefault(e=> e.Id == id);
            if (accion == null)
            {
                throw new EntidadNoEncontradaException("No se encontró la acción");
            }
            return accion;
        }
    }
}