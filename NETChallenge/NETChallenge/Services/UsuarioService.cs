using challenge.Models;
using NETChallenge.Data;
using NETChallenge.Exceptions;
using NETChallenge.Services.Validaciones;

namespace challenge.Services
{
    public class UsuarioService
    {
        private readonly ContextDB _context;
        private readonly UsuarioValidadorService _usuarioValidadorService;
        public UsuarioService(ContextDB contextDb, UsuarioValidadorService usuarioValidadorService)
        {
            _context = contextDb;
            _usuarioValidadorService = usuarioValidadorService;
        }
        public Usuario GetByNombreUsuario(string nombreUsuario)
        {
            var usuario = _context.Usuario.FirstOrDefault(e => e.NombreUsuario == nombreUsuario);
            if (usuario == null)
            {
                throw new EntidadNoEncontradaException("No se encontró el usuario.");
            }
            return usuario;
        }
        public Usuario Login(string nombreUsuario, string contraseñaIngresada)
        {
            _usuarioValidadorService.ValidarCreacion(nombreUsuario, contraseñaIngresada);
            var usuario = GetByNombreUsuario(nombreUsuario);
            _usuarioValidadorService.ValidarContraseña(usuario.Contraseña, contraseñaIngresada);
            return usuario;
        }
    }
}
