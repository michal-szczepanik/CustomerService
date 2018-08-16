using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilterAttribute> logger;

        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger)
        {
            this.logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            logger.LogCritical(context.Exception.ToString());

            context.Result = new ViewResult { ViewName = "Error" };
        }
    }
}