using System.Security.Claims;

namespace NameOverride.IntegrationTests.Setup;

[ExcludeFromCodeCoverage]
public class IntegrationAppFactory : WebApplicationFactory<Program> 
{
    public static string DefaultUserId => "2247d1cdece24b7aa397eb93bd1f18ea";

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services => services.AddSingleton<IStartupFilter>(new AutoAuthorizeStartupFilter()));
        return base.CreateHost(builder);
    }

    internal class AutoAuthorizeStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.UseMiddleware<AutoAuthorizeMiddleware>();
                next(builder);
            };
        }
    }

    internal class AutoAuthorizeMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext httpContext)
        {
            var identity = new ClaimsIdentity("cookies");

            identity.AddClaim(new Claim("Id", DefaultUserId));
            identity.AddClaim(new Claim("Name", "Jeziel Moura"));
            identity.AddClaim(new Claim("Email", "jezielmoura@outlook.com"));

            httpContext.User.AddIdentity(identity);

            await next.Invoke(httpContext);
        }
    }
}
