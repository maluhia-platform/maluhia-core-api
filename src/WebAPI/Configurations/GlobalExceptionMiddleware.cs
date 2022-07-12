using WebAPI.Middlewares;

namespace WebAPI.Configurations;

public static class GlobalExceptionMiddleware
{
    public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}