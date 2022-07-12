using CrossCutting.Exceptions;
using Maluhia.Core.Filters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Middlewares;

public class ExceptionMiddleware : ExceptionFilterAttribute
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> _logger)
    {
        _next = next;
        this._logger = _logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (DomainException ex)
        {
            _logger.LogError(ex, "Message: {0} ||Domain: {1} || Method: {2}",ex.Message,ex.Data["Domain"],ex.Data["Method"]);
            
            await DomainExceptionHandler.Handle(httpContext, ex);
        }
    }
}