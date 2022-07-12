using System.Net;
using System.Text.Json;

namespace Maluhia.Core.Filters;

public class DomainExceptionHandler
{
    public static Task Handle(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorDetails = new GlobalErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        };

        var text = JsonSerializer.Serialize(errorDetails);
        return context.Response.WriteAsync(text);
    }
}