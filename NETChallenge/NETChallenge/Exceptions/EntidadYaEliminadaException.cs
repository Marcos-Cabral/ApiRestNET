using NETChallenge.Attributes;

namespace NETChallenge.Exceptions
{
    [HttpStatusCode(400)]
    public class EntidadYaEliminadaException: Exception
    {
        public static string Message = "La entidad ya se encuentra eliminada";
        public EntidadYaEliminadaException() : base(Message)
        {
        }
    }
}
