using EasyTMS.Auth.BusinessContract.DTO;
using EasyTMS.Auth.RepositoryContract.Entity;

namespace EasyTMS.Auth.BusinessContract.Service
{
  public interface ITokenService
  {
    TokensResponse? GenerateTokenPair(CoreUser user);
  }
}
