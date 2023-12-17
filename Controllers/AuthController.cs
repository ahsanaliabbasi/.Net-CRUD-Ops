using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {

            var IdentityUser = new IdentityUser
            {
                UserName = registerUserDTO.Username,
                Email = registerUserDTO.Username

            };
            var IdentityResult= await userManager.CreateAsync(IdentityUser, registerUserDTO.Password);

            if (IdentityResult.Succeeded)
            {
                if (registerUserDTO.Roles!=null && registerUserDTO.Roles.Any()) {
                    IdentityResult = await userManager.AddToRolesAsync(IdentityUser, registerUserDTO.Roles);

                    if(IdentityResult.Succeeded)
                    {
                        return Ok("User Registration Successful !!!");
                    }

                }
            }
            return BadRequest(IdentityResult);

          
        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LogIn([FromBody] UserLogInDTO userLogInDTO)
        {
            var IdentityResult = await userManager.FindByEmailAsync(userLogInDTO.Username);

            var IdentityUser = new IdentityUser
            {
                UserName = userLogInDTO.Username,
                Email = userLogInDTO.Username
            };

            if (IdentityResult != null)
            {
               var CheckPasswordResult= await userManager.CheckPasswordAsync(IdentityResult, userLogInDTO.Password);
                if (CheckPasswordResult)
                {
                    return Ok(IdentityResult);
                }
                return BadRequest("Invalid Password..");

            }



            return BadRequest("User with provided Email is not registered .");
        }



    }
}
