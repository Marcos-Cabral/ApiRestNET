namespace challenge.Dto.Usuario
{
    public class UsuarioLoginDto
    {
        /// <summary>
        /// Nombre de usuario a iniciar sesión
        /// </summary>
        public string NombreUsuario { get; set; }
        /// <summary>
        /// Contraseña del usuario a iniciar sesión
        /// </summary>
        public string Contraseña { get; set; }
    }
}
