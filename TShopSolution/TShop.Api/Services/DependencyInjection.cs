using TShop.Api.Services.Authentication;

namespace TShop.Api.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenProvider, JwtTokenProvider>();

        return services;
    }
}
