using AutoMapper;
using FITCCRS2App.Services;
using FITCCRS2App.IdentityServer.Extensions;
using Serilog;

namespace FITCCRS2App.IdentityServer.Extensions;

public static class ServiceExtensions
{
    public static void AddAutoMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(MappingProfile));
    }

    public static void UseSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}