using Service.Auth.BusinessContract.Service;
using Service.Auth.BusinessImplement.Service;

namespace Service.Auth.BusinessImplement
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {
      services.AddScoped<IAuthService, AuthServiceImpl>();

      return services;
    }
  }
}
