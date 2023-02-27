using Microsoft.AspNetCore.Mvc;
using TermPaper.Api.Requests;
using TermPaper.Api.Services.AuthService;
using TermPaper.Shared.Entities;

namespace TermPaper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> RegisterUser(UserRegisterRequest request)
        {
            var response = await authService.RegisterUser(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> LoginUser(LoginRequest request)
        {
            var response = await authService.LoginUser(request);
            return Ok(response);
        }
    }
}
