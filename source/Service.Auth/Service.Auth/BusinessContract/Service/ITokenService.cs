using Service.Auth.BusinessContract.DTO;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.BusinessContract.Service
{
  public interface ITokenService
  {
    TokensResponse? GenerateTokenPair(CoreUser user);
  }
}
