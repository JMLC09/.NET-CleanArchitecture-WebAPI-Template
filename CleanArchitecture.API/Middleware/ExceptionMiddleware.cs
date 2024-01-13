using CleanArchitecture.API.Models;
using System.Net;

namespace CleanArchitecture.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next)
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
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomProblemDetails problem = new();

        //Aqui se manejan las excepciones que se definan en la capa de aplicacion
        switch (ex)
        {
            //Ejemplo ⬇️⬇
            //case BadRequestException badRequestException:
            //    statusCode = HttpStatusCode.BadRequest;
            //    problem = new CustomProblemDetails
            //    {
            //        Title = badRequestException.Message,
            //        Status = (int)statusCode,
            //        Type = nameof(BadRequestException),
            //        Detail = badRequestException.InnerException?.Message,
            //        Errors = badRequestException.Errors
            //    };
            //    break;
            default:
                problem = new CustomProblemDetails
                {
                    Title = ex.Message,
                    Status = (int)statusCode,
                    Type = nameof(HttpStatusCode.InternalServerError)
                };
                break;
        }
        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}
