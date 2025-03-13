using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApi.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private SignInManager<IdentityUser> _signInManager;

    public AuthController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }
    
    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout(Object empty)
    {
        //Body of the request should be included and be empty {}
        if (empty != null)
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
        return Unauthorized();
        
    }
}