using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TermPaper.Api.Requests;
using TermPaper.Api.Responses.User;
using TermPaper.Api.Services.TokenService;
using TermPaper.Shared.Entities;
using TermPaper.Shared.Enums;

namespace TermPaper.Api.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public AuthService(UserManager<User> userManager, IMapper mapper, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.tokenService = tokenService;
        }

        public async Task<LoginResponse> LoginUser(LoginRequest request)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);
            if (user is null)
            {
                return new LoginResponse() { Message = "UserName not found!" };
            }

            var result = await userManager.CheckPasswordAsync(user, request.Password);
            if (result)
            {
                return new LoginResponse() { Success = true, Token = tokenService.CreateToken(user)};
            }

            return new LoginResponse() { Message = "Password incorrect!" };
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest request)
        {
            var user = mapper.Map<UserRegisterRequest, User>(request);
            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, UserRoles.Client.ToString());
                return new UserRegisterResponse() { Success = true };
            }

            return new UserRegisterResponse() { Message = "Something went wrong!" };
        }
    }
}
