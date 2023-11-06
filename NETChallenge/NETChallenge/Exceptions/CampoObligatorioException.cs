using NETChallenge.Attributes;
using System.Net;

namespace NETChallenge.Exceptions
{
    [HttpStatusCode(400)]
    public class CampoObligatorioException: Exception
    {
        public CampoObligatorioException(string campo) : base($"El campo {campo} es obligatorio")
        {
        }
    }
}
