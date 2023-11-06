using NETChallenge.Attributes;

namespace NETChallenge.Exceptions
{
    [HttpStatusCode(400)]
    public class ContraseñaIncorrectaException : Exception
    {
        public ContraseñaIncorrectaException() : base($"La contraseña ingresada es incorrecta")
        {
        }
    }
}
