namespace AdoptMe.Presentation.Api.Controllers
{
    using AdoptMe.Application.DataObjects.Security;
    using AdoptMe.Application.Services.Implementation.Security;
    using AdoptMe.Presentation.Api.Models.Account;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly AccountService accountService;
        private readonly IMapper mapper;

        public AccountController(AccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
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
    }
}