using Serilog;

namespace WebAPI.Configurations;

public static class SerilogConfiguration
{
    public static WebApplicationBuilder UseSerilogConfiguration(this WebApplicationBuilder app)
    {
        app.Host.UseSerilog((ctx, conf) =>
        {
             conf.ReadFrom.Configuration(ctx.Configuration)
                 .WriteTo.Async(wt => wt.Console());
        });
        return app;
    }

}