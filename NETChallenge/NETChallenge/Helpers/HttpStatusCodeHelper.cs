using NETChallenge.Attributes;
using System.Net;

namespace NETChallenge.Helpers
{
    public class HttpStatusCodeHelper
    {
        public static int GetErrorCodeStatus(Exception ex)
        {
            var exceptionType = ex.GetType();
            var httpStatusCodeAttribute = exceptionType
                .GetCustomAttributes(typeof(HttpStatusCodeAttribute), true)
                .OfType<HttpStatusCodeAttribute>()
                .FirstOrDefault();

            return httpStatusCodeAttribute != null 
                        ? httpStatusCodeAttribute.StatusCode 
                        : (int) HttpStatusCode.InternalServerError;
        }
    }
}
