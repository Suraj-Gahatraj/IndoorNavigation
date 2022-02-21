using IndoorNavigation.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IndoorNavigation.Api.Controllers
{
    public class AccountController:ControllerBase

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        
        [AllowAnonymous]
        [HttpPost("/api/Login")]
        public async Task<IActionResult> Login(string userName, string password)
        {
           
            var user=await _userManager.FindByNameAsync(userName);       
            if(user!=null)
            {
                var signIn =await _signInManager.PasswordSignInAsync(userName, password, false, false);
                if(signIn.Succeeded)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("indoornavigation");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return Ok(new { Token = tokenHandler.WriteToken(token), UserId = user.Id });

                }

               
            }

            return NotFound();

        }


        [AllowAnonymous]
        [HttpPost("api/Register")]
        public async Task<IActionResult> Register(string firstName, string lastName, string userName, string password)
        {
            var userExist= await _userManager.FindByNameAsync(userName);
            if(userExist == null)
            {
                var user = new ApplicationUser()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = userName,
                };

                var result = await _userManager.CreateAsync(user, password);
                if(result.Succeeded)
                {
                    return Ok("User created Successfully");
                }

            }



            return Conflict("User is Already Registered");

        }

        [AllowAnonymous]
        [HttpGet("api/test")]
        public async Task<IActionResult> Test()
        {
            return Ok(" I will Run");
        }
    }
}
