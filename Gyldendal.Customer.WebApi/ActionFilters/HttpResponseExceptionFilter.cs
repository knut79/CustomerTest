using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Gyldendal.Customer.Core.Exceptions;
using System;

namespace Gyldendal.Customer.WebApi.ActionFilters
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is CustomDbException customDbException)
            {
                context.Result = new ObjectResult($"Something went wrong with the DB {customDbException.Message}")
                {
                    StatusCode = customDbException.StatusCode,
                };
                context.ExceptionHandled = true;
            }
            else
            {
                var exception = context.Exception;
                if (exception != null)
                {
                    context.Result = new ObjectResult($"Something went wrong. Contact customer support. {context.HttpContext.TraceIdentifier}")
                    {
                        StatusCode = 500,
                    };
                    context.ExceptionHandled = true;
                }
            }
        }
    }
}
