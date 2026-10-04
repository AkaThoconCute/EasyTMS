using Service.Auth.Insfratructure.Context;

namespace Service.Auth.Insfratructure.Configuration
{
  public static class DatabaseConfigs
  {
    public static IServiceCollection AddDatabaseConfigs(this IServiceCollection services)
    {
      services.AddDbContext<CoreDBContext>();
      return services;
    }

    public static async Task CheckDatabase(this IHost host)
    {
      using IServiceScope scope = host.Services.CreateScope();
      IServiceProvider services = scope.ServiceProvider;
      CoreDBContext context = services.GetRequiredService<CoreDBContext>();
      ILogger<CoreDBContext> logger = services.GetRequiredService<ILogger<CoreDBContext>>();

      try
      {
        if (await context.Database.CanConnectAsync())
          logger.LogInformation(">>> DATABASE CONNECTION: SUCCESS <<<");
        else
          logger.LogWarning(">>> DATABASE CONNECTION: FAILED <<<");
      }
      catch (Exception e)
      {
        logger.LogError(">>> DATABASE CONNECTION: ERROR! <<<");
        logger.LogError(">>> Error message: {Message}", e.Message);
      }
    }
  }
}
