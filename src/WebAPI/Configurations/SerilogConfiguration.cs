using Serilog;
using Serilog.Exceptions;

namespace WebAPI.Configurations;

public static class SerilogConfiguration
{
    public static WebApplicationBuilder UseSerilogConfiguration(this WebApplicationBuilder app)
    {
        app.Host.UseSerilog((ctx, conf) =>
        {
             conf.Enrich.WithMachineName()
                 .Enrich.WithExceptionDetails()
                 .Enrich.WithEnvironmentName()
                 .WriteTo.Async(wt => wt.Console());
        });
        return app;
    }

}