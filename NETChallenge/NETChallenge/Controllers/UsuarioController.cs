using challenge.Dto.Usuario;
using challenge.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETChallenge.Helpers;

namespace NETChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;
        private JwtService _jwtService;

        public UsuarioController(UsuarioService UsuarioService, JwtService jwtService)
        {
            _usuarioService = UsuarioService;
            _jwtService = jwtService;
        }
        /// <summary>
        /// Endpoint que autoriza al usuario ingresar al sistema
        /// </summary>
        /// <returns>Token para utilizar como autorizador del sistema</returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UsuarioLoginDto usuario)
        {
            var usuarioLogueado = _usuarioService.Login(usuario.NombreUsuario, usuario.Contraseña);
            var token = _jwtService.GetToken(usuarioLogueado.Id, usuarioLogueado.NombreUsuario);

            return ResponseHelper.ArmarRespuestaExitosa(token);
        }
    }
}