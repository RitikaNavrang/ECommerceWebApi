using SchoolCleanArchitecture;
using Serilog;
using System.Net;

namespace ECommerceWebApi.GlobalExcptionHandling
{
    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _next;


        public GlobalExceptionHandling(RequestDelegate next)
        {

            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int status;
            status = exception switch
            //var message = exception switch
            {
                //AccessViolationException => "Access violation error from the custom middleware",
                //DivideByZeroException => exception.Message,
                //Exception=> exception.Message,

                //_ => "Internal Server Error from the custom middleware."

                AccessViolationException => StatusCodes.Status404NotFound,
                DivideByZeroException => StatusCodes.Status403Forbidden,
                Exception => StatusCodes.Status500InternalServerError,

            };

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = status,//context.Response.StatusCode,
                Message = exception.Message,
                InnerException = exception.Source,
            }.ToString());
        }

    }
}
