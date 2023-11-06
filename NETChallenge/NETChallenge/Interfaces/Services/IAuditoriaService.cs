using challenge.Dto.Auditoria;
using NETChallenge.Enums;

namespace NETChallenge.Interfaces.Services
{
    public interface IAuditoriaService
    {
        void RegistrarAuditoria(TiposOperacionesAuditoria tipoOperacion, string tabla);
        List<AuditoriaGetDto> GetAll();
    }
}
