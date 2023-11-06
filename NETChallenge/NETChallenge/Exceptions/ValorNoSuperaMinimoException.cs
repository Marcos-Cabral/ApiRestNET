using NETChallenge.Attributes;

namespace NETChallenge.Exceptions
{
    [HttpStatusCode(400)]
    public class ValorNoSuperaMinimoException : Exception
    {
        public ValorNoSuperaMinimoException(string campo, string maximo) : base($"El campo {campo} debe ser mayor a {maximo}")
        {
        }
    }
}
