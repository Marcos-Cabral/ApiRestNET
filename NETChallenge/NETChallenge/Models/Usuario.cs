using System.ComponentModel.DataAnnotations;

namespace challenge.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
