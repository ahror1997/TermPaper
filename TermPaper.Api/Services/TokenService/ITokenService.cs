using TermPaper.Shared.Entities;

namespace TermPaper.Api.Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
