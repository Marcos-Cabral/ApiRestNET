using System.ComponentModel.DataAnnotations;

namespace NETChallenge.Models
{
    public class TipoOperacionAuditoria
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public ICollection<Auditoria> Auditorias { get; set; }
    }
}
