using Api.Auth.Models;
using Api.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Auth
{
    public class AuthController : BaseController
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("token")]
        public async Task<TokenResponseModel> Token([FromBody] TokenRequestModel request)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(request.Email);
            // Placeholder logic for user authentication
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new TokenResponseModel
                {
                    AccessToken = "mock-jwt-token"
                };
            }
            return new TokenResponseModel();
        }
    }
}
