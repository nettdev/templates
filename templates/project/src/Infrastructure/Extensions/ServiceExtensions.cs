using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using OpenTelemetry.Logs;
using Npgsql;
using OpenTelemetry.Resources;
using NameOverride.Infrastructure.Persistence.Context;

namespace NameOverride.Infrastructure.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceExtensions
{
    private const string ServiceName = "Travel";
    private const string ServiceNamespace = "Apps";
    private const string DeploymentAttribute = "deployment.environment.name";

    public static void ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(configuration["POSTGRES"]);
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<AppDbContext>(builder => 
            builder.UseNpgsql(dataSource, options => 
                options.EnableRetryOnFailure(5)));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());
    }

    public static void ConfigureTelemetry(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddSingleton(TracerProvider.Default.GetTracer(ServiceName));

        services.AddOpenTelemetry()
            .ConfigureResource(resourceBuilder => resourceBuilder
                .AddService(ServiceName, ServiceNamespace)
                .AddAttributes([new(DeploymentAttribute, environment.EnvironmentName)]))
            .WithMetrics(meterBuilder => meterBuilder
                .AddMeter(ServiceName)
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddNpgsqlInstrumentation()
                .AddOtlpExporter())
            .WithTracing(tracerBuilder => tracerBuilder
                .AddSource(ServiceName)
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddNpgsql()
                .AddOtlpExporter())
            .WithLogging((loggerBuilder) => loggerBuilder
                .AddOtlpExporter(), options => (options.IncludeScopes, options.IncludeFormattedMessage) = (true, true));
    }
}
