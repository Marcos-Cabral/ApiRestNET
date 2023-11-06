using System.ComponentModel.DataAnnotations;

namespace NETChallenge.Models
{
    public class EstadoOrdenDeInversion
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        public virtual ICollection<OrdenDeInversion> OrdenDeInversiones { get; set; }
    }
}
