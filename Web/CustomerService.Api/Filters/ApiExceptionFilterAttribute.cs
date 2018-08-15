using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = context.Exception is ArgumentException
                ? new JsonResult(HttpStatusCode.BadRequest)
                : new JsonResult(HttpStatusCode.InternalServerError);
        }
    }
}