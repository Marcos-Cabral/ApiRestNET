using System.ComponentModel.DataAnnotations;

namespace NETChallenge.Models
{
    public class OrdenDeInversionOperacion
    {
        [Key]
        public int Id { get; set; }
        public char Identificador { get; set; }
        public virtual ICollection<OrdenDeInversion> OrdenDeInversiones { get; set; }
    }
}
