using Microsoft.AspNet.Identity;
using NETChallenge.Exceptions;

namespace NETChallenge.Services.Validaciones
{
    public class UsuarioValidadorService
    {
        public UsuarioValidadorService()
        {
        }

        public void ValidarCreacion(string usuario, string password)
        {
            ValidarCampo(usuario, "Nombre de usuario");
            ValidarCampo(password, "Contraseña");
        }
        public void ValidarCampo(string campo, string descripcion)
        {
            if (string.IsNullOrEmpty(campo))
            {
                throw new CampoObligatorioException(descripcion);
            }
        }
        public void ValidarContraseña(string contraseñaUsuario, string contraseñaIngresada)
        {
            var contraseñaValida = new PasswordHasher().VerifyHashedPassword(contraseñaUsuario, contraseñaIngresada);
            if (contraseñaValida != PasswordVerificationResult.Success)
            {
                throw new ContraseñaIncorrectaException();
            }
        }
    }
}
