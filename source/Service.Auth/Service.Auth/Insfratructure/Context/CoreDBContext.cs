using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Service.Auth.RepositoryContract.Entity;

namespace Service.Auth.Insfratructure.Context
{
  public class CoreDBContext : IdentityDbContext<CoreUser>
  {
  }
}
