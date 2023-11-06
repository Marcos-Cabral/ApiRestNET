using System.Net;

namespace NETChallenge.Dto
{
    public class AnswerApi
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
