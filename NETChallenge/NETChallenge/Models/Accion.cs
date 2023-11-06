using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETChallenge.Models
{
    public class Accion
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Ticker { get; set; }   
        [MaxLength(100)]
        public string Nombre { get; set; }   
        [Column(TypeName = "decimal(14,2)")]
        public decimal PrecioUnitario { get; set; }   
    }
}
