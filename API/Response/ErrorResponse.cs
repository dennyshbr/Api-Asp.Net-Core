using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Response
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string[] Detalhes { get; set; }
        public ErrorResponse InnerError { get; set; }

        public static ErrorResponse From(Exception ex)
        {
            if (ex == null)
                return null;

            return new ErrorResponse()
            {
                Codigo = ex.HResult,
                Mensagem = ex.Message,
                InnerError = From(ex.InnerException)
            };
        }

        public static ErrorResponse FromModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);

            return new ErrorResponse()
            {
                Codigo = 100,
                Mensagem = "Houve erro(s) no envio da requisição.",
                Detalhes = erros.Select(e => e.ErrorMessage).ToArray()
            };
        }
    }
}
