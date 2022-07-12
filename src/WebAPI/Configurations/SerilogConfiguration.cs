using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.SystemConsole.Themes;

namespace WebAPI.Configurations;

public static class SerilogConfiguration
{
    public static WebApplicationBuilder UseSerilogConfiguration(this WebApplicationBuilder app)
    {
        app.Host.UseSerilog((ctx, conf) =>
        {
            if (ctx.HostingEnvironment.IsDevelopment())
                conf.MinimumLevel.Verbose();
            else
                conf.MinimumLevel.Information();

            conf.MinimumLevel.Override("System", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information);
                
            conf.Enrich.WithExceptionDetails()
                .Enrich.WithMachineName()
                .WriteTo.Async(wt => wt.Console(
                        restrictedToMinimumLevel: LogEventLevel.Information,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception} {Properties:j}",
                        theme: AnsiConsoleTheme.Code
                ));
        });
        return app;
    }

}