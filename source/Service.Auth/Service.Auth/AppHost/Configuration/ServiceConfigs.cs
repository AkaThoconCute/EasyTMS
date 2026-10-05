using Service.Auth.BusinessContract.Service;
using Service.Auth.BusinessImplement.Service;

namespace Service.Auth.AppHost.Configuration
{
  public static class ServiceConfigs
  {
    public static IServiceCollection AddServiceConfigs(this IServiceCollection services)
    {
      services.AddScoped<IAuthService, AuthServiceImpl>();
      services.AddScoped<IUserService, UserServiceImpl>();
      services.AddScoped<ITokenService, TokenServiceImpl>();

      return services;
    }
  }
}
