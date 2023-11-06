using NETChallenge.Attributes;
using System.Net;

namespace NETChallenge.Exceptions
{
    [HttpStatusCode(404)]
    public class EntidadNoEncontradaException : Exception
    {
        public EntidadNoEncontradaException(string message) : base(message)
        {
        }
    }
}
