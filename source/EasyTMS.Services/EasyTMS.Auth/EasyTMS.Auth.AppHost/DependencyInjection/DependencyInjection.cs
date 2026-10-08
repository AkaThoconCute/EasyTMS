using EasyTMS.Auth.BusinessContract.Service;
using EasyTMS.Auth.BusinessImplement.Service;

namespace EasyTMS.Auth.AppHost.DependencyInjection
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
      services.AddScoped<IAuthService, AuthServiceImpl>();
      services.AddScoped<IUserService, UserServiceImpl>();
      services.AddScoped<ITokenService, TokenServiceImpl>();

      return services;
    }
  }
}
