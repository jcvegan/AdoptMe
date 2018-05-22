namespace AdoptMe.Presentation.Api.Controllers
{
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Definition.Security;
    using AdoptMe.Data.Container.Context;
    using AdoptMe.Data.Domains.Security;
    using AdoptMe.Presentation.Api.Auth;
    using AdoptMe.Presentation.Api.Models.Account;
    using AdoptMe.Presentation.Api.Options;
    using AdoptMe.Presentation.Api.Utils;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Route("api/account")]
    [Produces("application/json")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly AdoptMeDataContext context;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;

        public AccountController(AdoptMeDataContext context, IAccountService accountService, IMapper mapper,UserManager<User> userManager,SignInManager<User> signInManager, IConfiguration configuration)
        {
            this.context = context;
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
            //if (ModelState.IsValid)
            //{
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            var user = await userManager.Users.SingleAsync(i => i.UserName == model.Username);
            var response = GetLoginToken.Execute(user, context);
            return Ok(response);

            //COMENTADO 2
            //var identity = await GetClaimsIdentity(model.Username, model.Password);
            //if (identity == null)
            //{
            //    return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            //}

            //var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, model.Username, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            //return new OkObjectResult(jwt);

            ///comentado 1
            //    var user = await userManager.FindByNameAsync(model.Username);
            //    if(user != null)
            //    {
            //        if(!await signInManager.CanSignInAsync(user) && (userManager.SupportsUserLockout && await userManager.IsLockedOutAsync(user))){
            //            return BadRequest();
            //        }
            //        if (!await userManager.CheckPasswordAsync(user, model.Password))
            //        {
            //            // Return bad request if the password is invalid
            //            return BadRequest();
            //        }
            //        if (userManager.SupportsUserLockout)
            //        {
            //            await userManager.ResetAccessFailedCountAsync(user);
            //        }

            //        //var principal = await signInManager.CreateUserPrincipalAsync(user);

            //        List<Claim> claims = new List<Claim>()
            //        {
            //            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            //            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //        };

            //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //        DateTime expiresOn = DateTime.Now.AddDays(1);
            //        var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
            //          configuration["Jwt:Issuer"],
            //          claims,
            //          expires: expiresOn,
            //          signingCredentials: creds);
            //        return new ObjectResult(new { Token= new JwtSecurityTokenHandler().WriteToken(token), Expires = expiresOn });
            //    }
            //    else
            //    {
            //        return BadRequest();
            //    }
            //}
            //else
            //{
            //    return BadRequest();
            //}
        }

        //private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        //{
        //    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        //        return await Task.FromResult<ClaimsIdentity>(null);

        //    // get the user to verifty
        //    var userToVerify = await userManager.FindByNameAsync(userName);

        //    if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

        //    // check the credentials
        //    if (await userManager.CheckPasswordAsync(userToVerify, password))
        //    {
        //        return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
        //    }

        //    // Credentials are invalid, or account doesn't exist
        //    return await Task.FromResult<ClaimsIdentity>(null);
        //}
    }
}