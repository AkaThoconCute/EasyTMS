using Service.Auth.AppHost.Common.ResultHandler;
using Service.Auth.BusinessContract.DTO;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.BusinessContract.Service
{
  public interface ITokenService
  {
    ServiceResult<TokensResponse> GenerateTokenPair(CoreUser user);
  }
}
