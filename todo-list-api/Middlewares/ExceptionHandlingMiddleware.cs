using System.Net;
using System.Text.Json;
using todo_list_api.Exceptions;


namespace todo_list_api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode;
            string? stackTrace = String.Empty;
            string message;

            switch (ex)
            {
                case ResourceNotFoundException :
                    message = ex.Message;
                    statusCode = HttpStatusCode.NotFound;
                    stackTrace = ex.StackTrace;
                    break;

                case BadRequestException :
                    message = ex.Message;
                    statusCode = HttpStatusCode.BadRequest;
                    stackTrace = ex.StackTrace;
                    break;

                default:
                    message = "Erro interno do servidor";
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new { statusCode, message, stackTrace });
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsync(result);
        }

    }
}