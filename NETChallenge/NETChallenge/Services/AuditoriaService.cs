using challenge.Dto.Auditoria;
using NETChallenge.Data;
using NETChallenge.Enums;
using NETChallenge.Interfaces.Services;
using NETChallenge.Models;

namespace NETChallenge.Services
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly ContextDB _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditoriaService(ContextDB context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void RegistrarAuditoria(TiposOperacionesAuditoria tipoOperacion, string tabla)
        {
            var usuario = _httpContextAccessor.HttpContext.Items["UserId"];
            _context.Auditoria.Add(new Auditoria
            {
                 Fecha = DateTime.UtcNow,
                 TipoOperacionAuditoriaId = (int)tipoOperacion,
                 Tabla = tabla,
                 UsuarioId = Convert.ToInt32(usuario)
            });
        }

        public List<AuditoriaGetDto> GetAll()
        {
            return _context.Auditoria
                .Select(e=> new AuditoriaGetDto
                {
                    Id = e.Id,
                    Fecha = e.Fecha,
                    NombreUsuario = e.Usuario.NombreUsuario,
                    Tabla = e.Tabla,
                    TipoOperacionAuditoria = e.TipoOperacionAuditoria.Descripcion,
                    TipoOperacionAuditoriaId = e.TipoOperacionAuditoriaId ,
                    UsuarioId = e.UsuarioId 
                }).ToList();
        }
    }
}