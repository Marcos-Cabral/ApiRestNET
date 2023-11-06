using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETChallenge.Models
{
    public class OrdenDeInversion
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int CuentaId { get; set; }
        [Required]
        public int Cantidad { get; set;}
        [Required]
        [Column(TypeName = "decimal(14,2)")]
        public decimal Precio { get; set;}
        [Required]
        public int OrdenDeInversionOperacionId { get; set;}
        public int EstadoId { get; set;}
        public int TipoDeActivoId {get;set;}
        [Column(TypeName = "decimal(14,2)")]
        public decimal MontoTotal { get; set;}
        public int? AccionId {get;set;}
        public Accion Accion {get;set;}
        public DateTime? FechaBaja { get;set; }
        public EstadoOrdenDeInversion Estado { get; set; }
        public TipoDeActivo TipoDeActivo { get; set; }
        public OrdenDeInversionOperacion OrdenDeInversionOperacion { get; set; }
    }
}
