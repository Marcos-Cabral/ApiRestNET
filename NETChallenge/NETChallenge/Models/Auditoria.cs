using challenge.Models;
using System.ComponentModel.DataAnnotations;

namespace NETChallenge.Models
{
    public class Auditoria
    {
        [Key]
        public int Id { get; set; }
        public int TipoOperacionAuditoriaId { get; set; }
        public DateTime Fecha { get; set; }
        [MaxLength(100)]
        public string Tabla { get; set; }
        public TipoOperacionAuditoria TipoOperacionAuditoria { get; set; }
        public int UsuarioId {get;set; }
        public Usuario Usuario { get; set; }
    }
}
