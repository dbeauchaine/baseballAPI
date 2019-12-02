using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseballAPI.Controllers
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(null)
                {
                    StatusCode = (int) exception.Status,
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
