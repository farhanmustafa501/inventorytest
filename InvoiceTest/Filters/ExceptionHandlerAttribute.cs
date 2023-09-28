using InvoiceTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace InvoiceTest.Filters;

public class ExceptionHandlerAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext filterContext)
    {
        Exception e = filterContext.Exception;
        filterContext.ExceptionHandled = true;

        int line = (new StackTrace(e, true)).GetFrame(0).GetFileLineNumber();

        filterContext.Result = new OkObjectResult(new ResponseDto { Status= false, StatusCode =  "500", Message = e.Message + ", at line # " + line });
    }
}