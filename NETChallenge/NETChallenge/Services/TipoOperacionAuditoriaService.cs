using NETChallenge.Data;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services
{
    public class TipoOperacionAuditoriaService : ITipoOperacionAuditoriaService
    {
        private readonly ContextDB _context;

        public TipoOperacionAuditoriaService(ContextDB context)
        {
            _context = context;
        }

        public List<TipoOperacionAuditoria> GetAll()
        {
            return _context.TipoOperacionAuditoria.ToList();
        }
    }
}