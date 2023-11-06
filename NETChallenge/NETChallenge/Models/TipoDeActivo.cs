using System.ComponentModel.DataAnnotations;

namespace NETChallenge.Models
{
    public class TipoDeActivo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32)]
        public string Descripcion { get; set; }
        public virtual ICollection<OrdenDeInversion> OrdenDeInversiones { get; set; }

    }
}
