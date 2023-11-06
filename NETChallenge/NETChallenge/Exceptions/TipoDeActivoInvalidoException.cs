using NETChallenge.Attributes;

namespace NETChallenge.Exceptions
{
    [HttpStatusCode(400)]
    public class TipoDeActivoInvalidoException: Exception
    {
        public static string Message = "El Tipo de Activo ingresado no es válido para la operación";
        public TipoDeActivoInvalidoException() : base(Message)
        {
        }
    }
}
