using Microsoft.AspNetCore.Mvc;
using NETChallenge.Dto;
using System.Net;

namespace NETChallenge.Helpers
{
    public class ResponseHelper
    {
        public static ActionResult ArmarRespuestaExitosa(object res)
        {
            var answerApi = new AnswerApi
            {
                Result = res,
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true
            };

            return new ObjectResult(answerApi);
        }

        public static AnswerApi ArmarRespuestaErronea(string mensaje, int statusCode)
        {
            return new AnswerApi
            {
                StatusCode = (HttpStatusCode)statusCode,
                IsSuccess = false,
                Message = mensaje
            };
        }
    }
}