namespace AdoptMe.Presentation.Api.Controllers
{
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Definition.Security;
    using AdoptMe.Data.Domains.Security;
    using AdoptMe.Presentation.Api.Models.Account;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;

        public AccountController(IAccountService accountService, IMapper mapper,UserManager<User> userManager,SignInManager<User> signInManager, IConfiguration configuration)
        {
            this.accountService = accountService;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateAccount([FromBody] NewAccountModel model)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(this.accountService.CreateAccountAsync(mapper.Map<UserDto>(model), model.Password));
                return BadRequest();
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [Route("{username}/validateName")]
        [HttpGet]
        public async Task<IActionResult> ValidateUserName(string username)
        {
            try
            {
                var existsUsername = await accountService.ExistsUserNameAsync(username);
                return new ObjectResult(new { IsValid = !existsUsername });
            }
            catch(Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [Route("{email}/validateEmail")]
        [HttpGet]
        public async Task<IActionResult> ValidateEmail(string email)
        {
            try
            {
                var existsEmail = await accountService.IsEmailAssociatedAsync(email);
                return new ObjectResult(new { IsValid = !existsEmail });
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody]LogInModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if(user != null)
                {
                    if(!await signInManager.CanSignInAsync(user) && (userManager.SupportsUserLockout && await userManager.IsLockedOutAsync(user))){
                        return BadRequest();
                    }
                    if (!await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        // Return bad request if the password is invalid
                        return BadRequest();
                    }
                    if (userManager.SupportsUserLockout)
                    {
                        await userManager.ResetAccessFailedCountAsync(user);
                    }

                    //var principal = await signInManager.CreateUserPrincipalAsync(user);

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    DateTime expiresOn = DateTime.Now.AddDays(1);
                    var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                      configuration["Jwt:Issuer"],
                      claims,
                      expires: expiresOn,
                      signingCredentials: creds);
                    return new ObjectResult(new { Token= new JwtSecurityTokenHandler().WriteToken(token), Expires = expiresOn });
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}