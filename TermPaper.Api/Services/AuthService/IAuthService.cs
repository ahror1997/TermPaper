using TermPaper.Api.Requests;
using TermPaper.Api.Responses.User;

namespace TermPaper.Api.Services.AuthService
{
    public interface IAuthService
    {
        Task<UserRegisterResponse> RegisterUser(UserRegisterRequest request);
        Task<LoginResponse> LoginUser(LoginRequest request);
    }
}
