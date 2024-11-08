using Microsoft.AspNetCore.Identity;

namespace NZWalks.Api.Repositories;

public interface ITokenRepository
{
    string CreateJwTToken(IdentityUser user, List<string> roles);
}
