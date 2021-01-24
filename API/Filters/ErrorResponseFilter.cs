using API.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class ErrorResponseFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorReponse = ErrorResponse.From(context.Exception);

            context.Result = new ObjectResult(errorReponse) { StatusCode = 500 };
        }
    }
}
